using BarberHub.Data.Models;
using BarberHub.Services.Core;
using BarberHub.Web.Data;
using BarberHub.Web.ViewModels.Offer;
using BarberHub.Web.ViewModels.SelectOffer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Service
{
    [TestFixture]
    public class SelectOfferServiceTests
    {
        private ApplicationDbContext dbContext = null!;
        private SelectOfferService selectOfferService = null!;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            dbContext = new ApplicationDbContext(options);

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

            dbContext.Barbershops.Add(shop);

            Offer firstOffer = new Offer() { Name = "Haircut", Description = "Basic haircut", Price = 20m, BarbershopId = shop.Id };
            dbContext.Offers.Add(firstOffer);

            Offer secondOffer = new Offer() { Name = "Beard Trim", Description = "Beard styling", Price = 15m, BarbershopId = shop.Id };
            dbContext.Offers.Add(secondOffer);

            dbContext.SaveChanges();

            selectOfferService = new SelectOfferService(dbContext);
        }

        [Test]
        public async Task AddSelectOfferAsync_AddsUserOfferSuccessfully()
        {
            List<string> offerIds = dbContext.Offers.Select(o => o.Id.ToString()).ToList();
            string barbershopId = dbContext.Offers.First().BarbershopId.ToString();
            string userId = Guid.NewGuid().ToString();

            await selectOfferService.AddSelectOfferAsync(offerIds, barbershopId, userId);


            List<UserOffer> userOffers = dbContext.UserOffers.ToList();
            Assert.AreEqual(2, userOffers.Count);
            Assert.IsTrue(userOffers.All(uo => uo.UserId == userId));
        }

        [Test]
        public async Task GetAllSelectOffersAsync_ReturnsCorrectOffers()
        {
            List<string> offerIds = dbContext.Offers.Select(o => o.Id.ToString()).ToList();
            string barbershopId = dbContext.Offers.First().BarbershopId.ToString();

            BarbershopSelectedOffersViewModel result = await selectOfferService.GetAllSelectOffersAsync(offerIds, barbershopId);

            Assert.NotNull(result);
            Assert.AreEqual(barbershopId, result.BarbershopId);
            Assert.AreEqual(2, (result.AllOffers.Count()));
            CollectionAssert.AreEquivalent(offerIds, result.AllOffers.Select(o => o.Id));
        }

        [Test]
        public async Task GetAllSelectOffersAsync_InvalidId_ReturnsEmptyList()
        {
            List<string> invalidIds = new List<string> { "1132323vssfsf1232gfdssafwd212" };
            string barbershopId = Guid.NewGuid().ToString();

            var result = await selectOfferService.GetAllSelectOffersAsync(invalidIds, barbershopId);

            Assert.NotNull(result);
            Assert.AreEqual(0, result.AllOffers.Count());
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

    }
}
