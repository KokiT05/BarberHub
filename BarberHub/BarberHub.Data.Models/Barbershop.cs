
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Data.Models
{
    [Comment("Barbershop in the system")]
    public class Barbershop
    {
        [Comment("Barbershop Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Barbershop Name")]
        public string Name { get; set; } = null!;

        [Comment("Barbershop Description")]
        public string? Description { get; set; }

        [Comment("Barbershop image url")]
        public string? ImageUrl { get; set; }

        [Comment("Barbershop City")]
        public string City { get; set; } = null!;

        [Comment("Barbershop Address")]
        public string Address { get; set; } = null!;

        [Comment("Barbershop opening time")]
        public TimeOnly? OpenTime { get; set; }

        [Comment("Barbershop closing time")]
        public TimeOnly? CloseTime { get; set; }

        [Comment("Show if barbershop is deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
