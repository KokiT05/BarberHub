using BarberHub.Services.Core.Interfaces;
using BarberHub.Web.ViewModels.Offer;
using BarberHub.Web.ViewModels.SelectOffer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BarberHub.Web.Controllers
{
    public class SelectOfferController : BaseController
    {
        private readonly ISelectOfferService selectOfferService;
        private readonly IOfferService offerService;

        public SelectOfferController(ISelectOfferService selectOfferService, IOfferService offerService)
        {
            this.selectOfferService = selectOfferService;
            this.offerService = offerService;
        }

        [HttpGet]
        public async Task<IActionResult> SelectOffer(SelectedOffersViewModel inputModel, string id)
        {
            //string id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //IEnumerable<AllOffersViewModel> allSelectOffer = await this.offerService
            //                                                        .GetAllOffersAsync()

            BarbershopSelectedOffersViewModel barbershopSelectedOffers =
                            await this.selectOfferService.GetAllSelectOffersAsync(inputModel.SelectedOfferIds, id);

            if (barbershopSelectedOffers == null || barbershopSelectedOffers.AllOffers.Count() == 0)
            {
                return this.RedirectToAction("All", "Barbershop");
            }

            return this.View(barbershopSelectedOffers);
        }

        [HttpPost]
		public async Task<IActionResult> ConfirmSelectOffer(CreateSelectOfferViewModel inputModel, string id)
        {
            try
            {
                //await this.selectOfferService.AddSelectOfferAsync(inputModel, id);

                return this.RedirectToAction("Idex", "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

				return this.RedirectToAction("Idex", "Home");
			}
        }

	}
}
