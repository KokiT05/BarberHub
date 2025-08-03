using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Data.Common
{
    public class EntityConstants
    {
        public static class Babershop
        {
            /// <summary>
            /// Barbershop Name should be at least 2 characters and up to 100 characters.
            /// </summary>
            public const int NameMinLength = 2;

            /// <summary>
            /// Barbershop Name should be able to store text with length up to 100 characters.
            /// </summary>
            public const int NameMaxLength = 100;

            /// <summary>
            /// Barbershop Description should be at least 2 characters and up to 1000 characters.
            /// </summary>
            public const int DescriptionMinLength = 2;

            /// <summary>
            /// Barbershop Description should be able to store text with length up to 1000 characters.
            /// </summary>
            public const int DescriptionMaxLength = 1000;

            /// <summary>
            /// Barbershop allowed min and max length for phone number
            /// </summary>
            public const int PhoneNumberMaxAndMinLength = 10;

            /// <summary>
            /// Maximum allowed length for image URL.
            /// </summary>
            public const int ImageUrlMaxLength = 2048;

            /// <summary>
            /// Barbershop City name should be at least 1 characters and up to 100 characters.
            /// </summary>
            public const int CityMinLength = 1;

            /// <summary>
            /// Barbershop City name should be able to store text with length up to 100 characters.
            /// </summary>
            public const int CityMaxlength = 100;

            /// <summary>
            /// Barbershop Address should be at least 1 characters and up to 100 characters.
            /// </summary>
            public const int AddressMinLength = 1;

            /// <summary>
            /// Barbershop Address should be able to store text with length up to 100 characters.
            /// </summary>
            public const int AddressMaxLength = 100;
        }
    }
}
