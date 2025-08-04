using BarberHub.Data.Models;
using BarberHub.Data.Models.Interfaces;
using BarberHub.Services.Core;
using BarberHub.Web.ViewModels.Barbershop;
using Microsoft.AspNetCore.Mvc;

namespace BarberHub.Web.Controllers
{
    public class BarbershopController : Controller
    {
        private readonly IBarbershopService barbershopService;
        public BarbershopController(IBarbershopService barbershopService)
        {
            this.barbershopService = barbershopService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllBarbershopsIndexViewModel> barbershops =
                                                await this.barbershopService.GetAllBarbershopsAsync();

            return this.View(barbershops);
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
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

        [HttpPost]
        public async Task<IActionResult> Edit(EditBarbershopViewModel inputModel)
        {
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FormBarbershopViewModel inputModel)
        {
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
    }
}
