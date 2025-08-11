using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public string? Comment { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime Date { get; set; }

        public bool IsActive { get; set; } = true;
        
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; }

        public Guid BarbershopId { get; set; }

        public Barbershop Barbershop { get; set; }
    }
}
