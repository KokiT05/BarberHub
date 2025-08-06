using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels.Offer
{
    using static BarberHub.Data.Common.EntityConstants;
    using static BarberHub.Data.Common.EntityConstants.OfferConstants;
    public class FormOfferViewModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        public string BarbershopId { get; set; } = null!;
    }
}
