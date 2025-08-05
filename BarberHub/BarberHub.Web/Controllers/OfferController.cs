using BarberHub.Services.Core.Interfaces;
using BarberHub.Web.ViewModels.Offer;
using Microsoft.AspNetCore.Mvc;

namespace BarberHub.Web.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;
        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<AllOffersViewModel> offers = await this.offerService.GetAllOffersAsync();

            return this.View(offers);
        }
    }
}
