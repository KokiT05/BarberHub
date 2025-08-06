using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels.SelectOffer
{
    public class SelectedOffersViewModel
    {
        [Required]
        public ICollection<string> SelectedOfferIds { get; set; } = new List<string>();

        [Required]
        public string BarbershopId { get; set; } = null!;

    }
}
