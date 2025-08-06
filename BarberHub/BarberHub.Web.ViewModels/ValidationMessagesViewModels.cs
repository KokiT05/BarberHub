using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels
{
    public class ValidationMessagesViewModels
    {
        public const string NameMinLengthErrorMessage = "The name must be at least 2 characters long.";
        public const string NameMaxLengthErrorMessage = "The name must be at most 100 characters long.";

        public const string DescriptionMinLengthErrorMessage = "The description must be at least 2 characters long.";
        public const string DescriptionMaxLengthErrorMessage = "The description must be at most 1000 characters long.";
        public static class OfferMessages
        {
            public const string PriceRangeErrorMessage = "The price must be between 1 and 999.99 BGN.";
        }
        public static class BarbershopMessages
        {

        }
    }
}
