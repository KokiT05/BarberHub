using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Data.Models
{
    [Comment("Offer in the system")]
    public class Offer
    {
        [Comment("Offer Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Offer Name")]
        public string Name { get; set; } = null!;

        [Comment("Offer Description")]
        public string? Description { get; set; }

        [Comment("Offer Price")]
        public decimal Price {  get; set; }

        [Comment("FK describe relation between Barbershop and Offer")]
        public Guid BarbershopId { get; set; }

        public virtual Barbershop Barbershop { get; set; } = null!;

		public virtual ICollection<UserOffer> UserOffers { get; set; } = new HashSet<UserOffer>();
	}
}
