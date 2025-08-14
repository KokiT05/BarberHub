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

    using static ValidationMessagesViewModels.OfferMessages;
    using static ValidationMessagesViewModels;
    public class EditOfferViewModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(NameMinLength, ErrorMessage = NameMinLengthErrorMessage)]
        [MaxLength(NameMaxLength, ErrorMessage = NameMaxLengthErrorMessage)]
        public string Name { get; set; } = null!;

        [MinLength(DescriptionMinLength, ErrorMessage = DescriptionMinLengthErrorMessage)]
        [MaxLength(DescriptionMaxLength, ErrorMessage = DescriptionMaxLengthErrorMessage)]
        public string? Description { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = PriceRangeErrorMessage)]
        public decimal Price { get; set; }

        public string BarbershopId { get; set; } = null!;
    }
}
