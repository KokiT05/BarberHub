using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels.Barbershop
{
    public class BarbershopPeginationViewModel
    {
        public IEnumerable<AllBarbershopsIndexViewModel> Barbershops {  get; set; } = new List<AllBarbershopsIndexViewModel>();

        public int TotalPages {  get; set; }
    }
}
