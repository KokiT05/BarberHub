using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels.Offer
{
    public class BarbershopAllOffersViewModel
    {
        public string? BarbershopId { get; set; }

        public IEnumerable<AllOffersViewModel> AllOffers { get; set; } = new List<AllOffersViewModel>();
    }
}
