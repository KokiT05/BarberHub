using BarberHub.Web.ViewModels.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels.SelectOffer
{
    public class BarbershopSelectedOffersViewModel
    {
        public IEnumerable<AllOffersViewModel> AllOffers { get; set; } = new List<AllOffersViewModel>();

        public string BarbershopId { get; set; } = null!;
    }
}
