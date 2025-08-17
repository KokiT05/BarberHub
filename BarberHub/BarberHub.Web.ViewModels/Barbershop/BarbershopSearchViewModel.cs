using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels.Barbershop
{
    public class BarbershopSearchViewModel
    {
        public string? SearchName { get; set; }

        public string? City { get; set; }

        public IEnumerable<AllBarbershopsIndexViewModel>? Barbershops { get; set; } = new List<AllBarbershopsIndexViewModel>();
    }
}
