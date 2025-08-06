using BarberHub.Services.Core.Interfaces;
using BarberHub.Web.ViewModels.Offer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BarberHub.Web.Controllers
{
    public class OfferController : BaseController
    {
        private readonly IOfferService offerService;
        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All(string? id)
        {
            IEnumerable<AllOffersViewModel> offers = await this.offerService.GetAllOffersAsync(id);

            return this.View(offers);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string? id)
        {
            FormOfferViewModel formOfferViewModel = new FormOfferViewModel();
            bool isValidId = Guid.TryParse(id, out Guid validId);
            if (isValidId)
            {
                formOfferViewModel.BarbershopId = id;
                return this.View(formOfferViewModel);
            }

            return this.Forbid();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FormOfferViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                await this.offerService.CreateOfferAsync(inputModel, inputModel.BarbershopId);

                return this.RedirectToAction(nameof(All), new { id = inputModel.BarbershopId });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(All), new { id = inputModel.BarbershopId });
            }
        }
    }
}
