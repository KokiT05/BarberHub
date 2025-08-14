using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels.SelectOffer
{
	public class CreateSelectOfferViewModel
	{
		public ICollection<string> SelectOffers { get; set; } = new List<string>();

		public string BarbershopId { get; set; } = null!;

		public DateTime SelectedOn { get; set; }
	}
}
