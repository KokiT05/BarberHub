using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Web.ViewModels.Barbershop
{
    public class AllBarbershopsIndexViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? PhoneNumber { get; set; }

        public string? ImageUrl { get; set; }

        public string City { get; set; } = null!;

        public string Address {  get; set; } = null!;

        public string? OpenTime { get; set; }

        public string? CloseTime { get; set; }
    }
}
