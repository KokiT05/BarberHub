using BarberHub.Data.Models;
using BarberHub.Services.Core;
using BarberHub.Web.Data;
using BarberHub.Web.ViewModels.Offer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Service
{

    [TestFixture]
    public class OfferServiceTest
    {
        private ApplicationDbContext dbContext;
        private OfferService offerService;
        private Guid barbershopId;
        private Offer firstOffer;
        private Barbershop barbershop;

        [SetUp]
        public void SetUp()
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

            barbershopId = shop.Id;

            firstOffer = new Offer() { Id = Guid.NewGuid(), Name = "Offer1", Description = "Desc1", Price = 10, BarbershopId = barbershopId };
            
             dbContext.Offers.Add(firstOffer);

            Offer secondOffer = new Offer() { Id = Guid.NewGuid(), Name = "Offer2", Description = "Desc2", Price = 20, BarbershopId = barbershopId };

             dbContext.Offers.Add(secondOffer);

             dbContext.SaveChanges();

            offerService = new OfferService(dbContext);
        }

        [Test]
        public async Task GetAllOffersAsync_ReturnsOffers_ForValidBarbershopId()
        {

            BarbershopAllOffersViewModel result = await offerService.GetAllOffersAsync(barbershopId.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.AllOffers.Count());
            Assert.AreEqual(barbershopId.ToString(), result.BarbershopId);
        }

        [Test]
        public async Task GetAllOffersAsync_ReturnsEmptyList_ForInvalidBarbershopId()
        {
            Guid testGuid = Guid.NewGuid();
            BarbershopAllOffersViewModel result = await offerService.GetAllOffersAsync(testGuid.ToString());

            Assert.IsNotNull(result);
            Assert.IsEmpty(result.AllOffers);
        }

        [Test]
        public async Task GetEditDetailsOfferAsync_ReturnsOffer_ForValidId()
        {
            Offer offer = dbContext.Offers.Where(o => o.Id == firstOffer.Id).First();

            EditOfferViewModel result = await offerService.GetEditDetailsOfferAsync(offer.Id.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(offer.Name, result.Name);
        }

        [Test]
        public async Task EditOfferAsync_UpdatesOffer_WhenValidId()
        {
            Offer offer = dbContext.Offers.First();
            EditOfferViewModel editModel = new EditOfferViewModel
            {
                Id = offer.Id.ToString(),
                Name = "OfferUpdated",
                Description = "UpdatedDesc",
                Price = 99,
                BarbershopId = offer.BarbershopId.ToString()
            };

            bool result = await offerService.EditOfferAsync(editModel);
            Offer updatedOffer = await dbContext.Offers.FindAsync(offer.Id);

            Assert.IsTrue(result);
            Assert.AreEqual("OfferUpdated", updatedOffer.Name);
            Assert.AreEqual(99, updatedOffer.Price);
        }

        [Test]
        public async Task CreateOfferAsync_AddsOffer_WhenValidBarbershopId()
        {
            FormOfferViewModel formModel = new FormOfferViewModel
            {
                Name = "OfferTest1",
                Description = "New Desc",
                Price = 50
            };

            await offerService.CreateOfferAsync(formModel, barbershopId.ToString());

            List<Offer> offers = dbContext.Offers.Where(o => o.Name == "OfferTest1").ToList();
            Assert.AreEqual(1, offers.Count);
            Assert.AreEqual(50, offers.First().Price);
        }

        [Test]
        public async Task DeleteOfferAsync_RemovesOffer_WhenValidId()
        {
            Offer offer = dbContext.Offers.First();

            bool result = await offerService.DeleteOfferAsync(offer.Id.ToString());
            Offer? deletedOffer = await dbContext.Offers.FindAsync(offer.Id);

            Assert.IsTrue(result);
            Assert.IsNull(deletedOffer);
        }

        [Test]
        public async Task DeleteOfferAsync_ReturnsFalse_WhenInvalidId()
        {
            Guid testGuid = Guid.NewGuid();
            bool result = await offerService.DeleteOfferAsync(testGuid.ToString());

            Assert.IsFalse(result);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
