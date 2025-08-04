using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels.Barbershop
{
    using static BarberHub.Data.Common.EntityConstants.Babershop;
    public class FormBarbershopViewModel
    {
        [Required(ErrorMessage = "Barbershop name is required")]
        [MinLength(NameMinLength, ErrorMessage = "Name must be at least 2 characters")]
        [MaxLength(NameMaxLength, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = null!;

        [MinLength(DescriptionMinLength, ErrorMessage = "Description must be at least 2 characters")]
        [MaxLength(DescriptionMaxLength, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        [Phone(ErrorMessage = "The format is not correct")]
        [StringLength(PhoneNumberMaxAndMinLength, ErrorMessage = "Phone number must be exactly 10 characters long", MinimumLength = PhoneNumberMaxAndMinLength)]
        public string? PhoneNumber { get; set; }

        [MaxLength(ImageUrlMaxLength, ErrorMessage = "Image URL cannot exceed 2048 characters")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MinLength(CityMinLength, ErrorMessage = "City must be at least 1 character")]
        [MaxLength(CityMaxlength, ErrorMessage = "City cannot exceed 100 characters")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Address is required")]
        [MinLength(AddressMinLength, ErrorMessage = "Address must be at least 1 character")]
        [MaxLength(AddressMaxLength, ErrorMessage = "Address cannot exceed 100 characters")]
        public string Address { get; set; } = null!;

        [DataType(DataType.Time)]
        public string? OpenTime { get; set; }

        [DataType(DataType.Time)]
        public string? CloseTime { get; set; }
    }
}
