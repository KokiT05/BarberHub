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
            BarbershopAllOffersViewModel? barbershopAllOffers = await this.offerService.GetAllOffersAsync(id);

            return this.View(barbershopAllOffers);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {

            try
            {
                EditOfferViewModel? editOffer = await this.offerService.GetEditDetailsOfferAsync(id);

                if (editOffer == null)
                {
                    return this.NotFound();
                }

                return this.View(editOffer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.NotFound();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditOfferViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                bool isEditSuccessfully = await this.offerService.EditOfferAsync(inputModel);

                if (!isEditSuccessfully)
                {
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(All), new {id = inputModel.BarbershopId});
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create(string? id)
        {
            bool isValidId = Guid.TryParse(id, out Guid validId);
            if (isValidId)
            {
				FormOfferViewModel formOfferViewModel = new FormOfferViewModel();
				formOfferViewModel.BarbershopId = id;
                return this.View(formOfferViewModel);
            }

            return this.NotFound();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(string id, string barbershopId)
        {
            try
            {
                bool isDeleteSuccessfully = await this.offerService
                                                    .DeleteOfferAsync(id);

                return this.RedirectToAction(nameof(All), new {id = barbershopId});
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);


                return this.RedirectToAction(nameof(All), new { id = barbershopId });
            }
        }
    }
}
