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

        public async Task<IActionResult> All()
        {
            IEnumerable<AllBarbershopsIndexViewModel> barbershops = 
                                                await this.barbershopService.GetAllBarbershopsAsync();

            return this.View(barbershops);
        }

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
    }
}
