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

        public async Task<IActionResult> All ()
        {
            IEnumerable<AllBarbershopsIndexViewModel> barbershops = 
                                                await this.barbershopService.GetAllBarbershops();

            return this.View(barbershops);
        }
    }
}
