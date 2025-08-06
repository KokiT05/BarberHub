using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels.Offer
{
    using static BarberHub.Data.Common.EntityConstants.OfferConstants;
    using static BarberHub.Data.Common.EntityConstants;
    public class EditOfferViewModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string? Description { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }
    }
}
