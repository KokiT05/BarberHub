using BarberHub.Data.Models;
using BarberHub.Services.Core;
using BarberHub.Web.Data;
using BarberHub.Web.ViewModels.Barbershop;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Service
{
     [TestFixture]
    public class BarbershopServiceTest
    {

        private ApplicationDbContext applicationDbContext;
        private BarbershopService barbershopService;
        private Guid firstBarbershopId;
        private Guid secondBarbershopId;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            applicationDbContext = new ApplicationDbContext(options);

            
            Barbershop shop = new Barbershop
            {
                Id = Guid.NewGuid(),
                Name = "Test Shop",
                Description = "This is a test description",
                PhoneNumber = "0888123456",
                City = "Sofia",
                Address = "Test Street 1",
                OpenTime = new TimeOnly(9, 0),
                CloseTime = new TimeOnly(18, 0)
            };
            firstBarbershopId = shop.Id;

            applicationDbContext.Barbershops.Add(shop);
            applicationDbContext.SaveChanges();

            Barbershop secondBarbershop = new Barbershop
            {
                Id = Guid.NewGuid(),
                Name = "Test Shop",
                Description = "This is a test description",
                PhoneNumber = "0882348724",
                City = "Test1",
                Address = "Test Street 1",
                OpenTime = new TimeOnly(9, 0),
                CloseTime = new TimeOnly(18, 0)
            };
            secondBarbershopId = secondBarbershop.Id;

            applicationDbContext.Barbershops.Add(secondBarbershop);
            applicationDbContext.SaveChanges();

            barbershopService = new BarbershopService(applicationDbContext);
        }

        [Test]
        public async Task GetAllBarbershopsAsync_ShouldReturnData()
        {
            IEnumerable<AllBarbershopsIndexViewModel> result = await barbershopService.GetAllBarbershopsAsync();
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllBarbershopsAsync_ShouldReturnEmptyCollection()
        {
            Barbershop firstBarbershop = await this.applicationDbContext.Barbershops.FirstAsync(b => b.Id == firstBarbershopId);
            Barbershop secondBarbershop = await this.applicationDbContext.Barbershops.FirstAsync(b => b.Id == secondBarbershopId);

            this.applicationDbContext.Barbershops.Remove(firstBarbershop);
            this.applicationDbContext.Barbershops.Remove(secondBarbershop);

            await this.applicationDbContext.SaveChangesAsync();

            IEnumerable<AllBarbershopsIndexViewModel> result = await this.barbershopService.GetAllBarbershopsAsync();
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task GetDetailsBarbershopAsync_ValidId_ShouldReturnDetails()
        {
            Barbershop shop = applicationDbContext.Barbershops.First();
            DetailsBarbershopViewModel result = await barbershopService.GetDetailsBarbershopAsync(shop.Id.ToString());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Test Shop"));
        }

        [Test]
        public async Task GetDetailsBarbershopAsync_ValidId_ShouldReturnDetailsEmptyViewModel()
        {
            Guid guid = Guid.NewGuid();
            DetailsBarbershopViewModel? result = await barbershopService.GetDetailsBarbershopAsync(guid.ToString());
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task CreateBarbershopAsync_ShouldAddBarbershop()
        {
            FormBarbershopViewModel newShop = new FormBarbershopViewModel
            {
                Name = "New Shop",
                Description = "New desc",
                PhoneNumber = "987654321",
                City = "New City",
                Address = "New Address",
                OpenTime = "09:00",
                CloseTime = "17:00",
                ImageUrl = null
            };

            await barbershopService.CreateBarbershopAsync(newShop);

            Assert.That(this.applicationDbContext.Barbershops.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task CreateBarbershopAsync_ShouldNotBeAddBarbershop()
        {
            FormBarbershopViewModel newShop = new FormBarbershopViewModel
            {
                Description = "New desc",
                PhoneNumber = "987654321",
                City = "New City",
                OpenTime = "09:00",
                CloseTime = "17:00",
                ImageUrl = null
            };

            Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(async Task() => { await barbershopService.CreateBarbershopAsync(newShop); });

            Assert.That(this.applicationDbContext.Barbershops.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task EditBarbershopAsync_ShouldEditData()
        {
            Barbershop shop = this.applicationDbContext.Barbershops.First();

            EditBarbershopViewModel editModel = new EditBarbershopViewModel
            {
                Id = shop.Id.ToString(),
                Name = "Edited Name",
                Description = "Edited Description",
                PhoneNumber = shop.PhoneNumber,
                City = shop.City,
                Address = shop.Address,
                OpenTime = "09:00",
                CloseTime = "18:00",
                ImageUrl = shop.ImageUrl
            };

            bool result = await barbershopService.EditBarbershopAsync(editModel);
            Assert.That(result, Is.True);

            Barbershop updatedShop = this.applicationDbContext.Barbershops.Find(shop.Id);
            Assert.That(updatedShop.Name, Is.EqualTo("Edited Name"));
        }

        [Test]
        public async Task EditBarbershopAsync_ShouldNotEditData()
        {
            Barbershop shop = this.applicationDbContext.Barbershops.First();

            EditBarbershopViewModel editModel = new EditBarbershopViewModel();

            bool result = await barbershopService.EditBarbershopAsync(editModel);
            Assert.That(result, Is.Not.True);

        }

        [Test]
        public async Task SoftDeleteAsync_ShouldMarkAsDeleted()
        {
            Barbershop shop = this.applicationDbContext.Barbershops.First();
            bool result = await barbershopService.SoftDeleteAsync(shop.Id.ToString());
            Assert.That(result, Is.True);

            Barbershop deletedShop = this.applicationDbContext.Barbershops.Find(shop.Id);
            Assert.That(deletedShop.IsDeleted, Is.True);
        }

        [Test]
        public async Task SoftDeleteAsync_ShouldNotMarkAsDeleted()
        {
            bool result = await barbershopService.SoftDeleteAsync(Guid.NewGuid().ToString());
            Assert.That(result, Is.Not.True);
        }

        [Test]
        public async Task HardDeleteAsync_ShouldRemoveEntity()
        {
            Barbershop shop = this.applicationDbContext.Barbershops.First();
            bool result = await barbershopService.HardDeleteAsync(shop.Id.ToString());
            Assert.That(result, Is.True);

            Assert.That(this.applicationDbContext.Barbershops.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task HardDeleteAsync_ShouldNotRemoveEntity()
        {
            bool result = await barbershopService.HardDeleteAsync(Guid.NewGuid().ToString());
            Assert.That(result, Is.Not.True);

            Assert.That(this.applicationDbContext.Barbershops.Count(), Is.EqualTo(2));
        }


        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
