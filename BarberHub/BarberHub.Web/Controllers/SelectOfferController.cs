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

        [HttpPost]
        public async Task<IActionResult> SelectOffer(SelectedOffersViewModel inputModel)
        {
            //string id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //IEnumerable<AllOffersViewModel> allSelectOffer = await this.offerService
            //                                                        .GetAllOffersAsync()

            IEnumerable<AllOffersViewModel> allSelectOffer = await this.offerService
                                                    .GetAllSelectOffersAsync(inputModel.SelectedOfferIds);

            return this.View(allSelectOffer);
        }
    }
}
