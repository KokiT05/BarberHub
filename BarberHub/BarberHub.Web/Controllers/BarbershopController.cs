using BarberHub.Data.Models;
using BarberHub.Data.Models.Interfaces;
using BarberHub.Services.Core;
using BarberHub.Web.ViewModels.Barbershop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarberHub.Web.Controllers
{
    public class BarbershopController : BaseController
    {
        private readonly IBarbershopService barbershopService;
        public BarbershopController(IBarbershopService barbershopService)
        {
            this.barbershopService = barbershopService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllBarbershopsIndexViewModel> barbershops =
                                                await this.barbershopService.GetAllBarbershopsAsync();

            return this.View(barbershops);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string? id)
        {
            try
            {
                DetailsBarbershopViewModel? detailsBarbershop =
                            await this.barbershopService.GetDetailsBarbershopAsync(id);

                if (detailsBarbershop == null)
                {
                    return this.RedirectToAction(nameof(All));
                }

                return this.View(detailsBarbershop);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(All));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
			if (this.IsAuthenticated() == false)
			{
                return this.Forbid();
			}

			try
            {

                EditBarbershopViewModel? editBarbershop =
                                    await this.barbershopService.GetEditDetailsBarbershopAsync(id);

                if (editBarbershop == null)
                {
                    return this.RedirectToAction(nameof(All));
                }

                return this.View(editBarbershop);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);


                return this.RedirectToAction(nameof(All));
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditBarbershopViewModel inputModel)
        {
            if (this.IsAuthenticated() == false)
            {
                return this.Forbid();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                bool isEditSuccessfully = await this.barbershopService.EditBarbershopAsync(inputModel);

                if (!isEditSuccessfully)
                {
                    return this.RedirectToAction(nameof(All));
                }

                return this.RedirectToAction(nameof(Details), new { id = inputModel.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(All));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (this.IsAuthenticated() == false)
            {
                return this.Forbid();
            }

            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(FormBarbershopViewModel inputModel)
        {
			if (this.IsAuthenticated() == false)
			{
				return this.Forbid();
			}

			if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                await this.barbershopService.CreateBarbershopAsync(inputModel);

                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                


                return this.RedirectToAction(nameof(All));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
			if (this.IsAuthenticated() == false)
			{
				return this.Forbid();
			}

			try
            {
                DeleteBarbershopViewModel? deleteBarbershop =
                                            await this.barbershopService.GetDeleteBarbershopAsync(id);

                if (deleteBarbershop == null)
                {
                    return this.RedirectToAction(nameof(All));
                }

                return this.View(deleteBarbershop);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteBarbershopViewModel inputModel)
        {
			if (this.IsAuthenticated() == false)
			{
				return this.Forbid();
			}

			try
            {
                bool deleteResult = await this.barbershopService.SoftDeleteAsync(inputModel.Id);

                return this.RedirectToAction(nameof(All));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(All));
            }
        }
    }
}
