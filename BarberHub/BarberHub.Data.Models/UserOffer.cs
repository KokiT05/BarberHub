using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Data.Models
{
    [Comment("Represents a selected offer by a user")]
    public class UserOffer
    {
        [Comment("Foreign key reference to the offer")]
        public Guid OfferId { get; set; }
        public virtual Offer Offer { get; set; } = null!;

		[Comment("Foreign key reference to the user")]
		public string UserId { get; set; } = null!;
		public virtual IdentityUser User { get; set; } = null!;

        [Comment("SelectOffer Description")]
        public string? Description { get; set; }

        [Comment("SelectOffer TotalPrice")]
        public decimal TotalPrice { get; set; }

        [Comment("Date and time when the offer was selected")]
        public DateTime SelectedOn { get; set; } = DateTime.Now;

        [Comment("Optional comment provided by the user")]
        public string? Comment {  get; set; }
    }
}
