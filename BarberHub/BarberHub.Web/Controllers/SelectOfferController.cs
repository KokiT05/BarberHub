using BarberHub.Services.Core.Interfaces;
using BarberHub.Web.ViewModels.SelectOffer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BarberHub.Web.Controllers
{
    public class SelectOfferController : BaseController
    {
        private readonly ISelectOfferService selectOfferService;

        public SelectOfferController(ISelectOfferService selectOfferService)
        {
            this.selectOfferService = selectOfferService;
        }

        [HttpPost]
        public async Task<IActionResult> SelectOffer(SelectedOffersViewModel inputModel)
        {
            string id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.selectOfferService.GetAllOffersAsync(inputModel, this.User.Identities.ToString());

            return this.NotFound();
        }
    }
}
