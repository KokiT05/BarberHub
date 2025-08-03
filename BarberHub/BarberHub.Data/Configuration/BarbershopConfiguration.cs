using BarberHub.Data.Models;
using BarberHub.GlobalCommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberHub.Data.Configuration
{
    using static Common.EntityConstants.Babershop;
    using static ApplicationConstants;
    public class BarbershopConfiguration : IEntityTypeConfiguration<Barbershop>
    {
        public void Configure(EntityTypeBuilder<Barbershop> model)
        {
            model.Property(b => b.Id);

            model.HasKey(b => b.Id);

            model.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            model.Property(b => b.Description)
                .HasMaxLength(DescriptionMaxLength);

            model.Property(b => b.ImageUrl).HasMaxLength(ImageUrlMaxLength);

            model.Property(b => b.City)
                .IsRequired()
                .HasMaxLength(CityMaxlength);

            model.Property(b => b.Address)
                .IsRequired()
                .HasMaxLength(AddressMaxLength);

            model.Property(b => b.OpenTime);
            model.Property(b => b.CloseTime);

            model.Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);

            model.HasData(this.SeedBarbershops());
        }

        public List<Barbershop> SeedBarbershops()
        {
            List<Barbershop> barbershops = new List<Barbershop>()
            {
                new Barbershop()
                {
                    Id = Guid.NewGuid(),
                    Name = "The Brothers",
                    Description = "Just a barbershop",
                    ImageUrl = $"~/images/{NoImageUrl}",
                    City = "Sofia",
                    Address = "бул. Ломско шосе",
                    OpenTime = new TimeOnly(8, 30),
                    CloseTime = new TimeOnly(20, 30),
                    IsDeleted = false
                },
                new Barbershop()
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                    Name = "Barber's Den",
                    Description = "Традиционна бръснарница с модерен привкус.",
                    ImageUrl = "https://example.com/barbersden.jpg",
                    City = "София",
                    Address = "ул. Витоша 15",
                    OpenTime = new TimeOnly(9, 0),
                    CloseTime = new TimeOnly(18, 0),
                    IsDeleted = false
                },
                new Barbershop()
                {
                    Id = Guid.Parse("f6e5d4c3-b2a1-0987-6543-210fedcba987"),
                    Name = "The Clip Joint",
                    Description = "Място, където стилът среща прецизността.",
                    ImageUrl = "https://example.com/clipjoint.png",
                    City = "Пловдив",
                    Address = "бул. Свобода 10",
                    OpenTime = new TimeOnly(10, 0),
                    CloseTime = new TimeOnly(19, 0),
                    IsDeleted = false
                },
                new Barbershop()
                {
                    Id = Guid.Parse("1a2b3c4d-5e6f-7890-abcd-ef1234567890"),
                    Name = "Gentlemen's Quarters",
                    Description = "Ексклузивна бръснарница за истински господа.",
                    ImageUrl = "https://example.com/gentlemensquarters.webp",
                    City = "Варна",
                    Address = "ул. Княз Борис I 25",
                    OpenTime = new TimeOnly(8, 30),
                    CloseTime = new TimeOnly(17, 30),
                    IsDeleted = false
                }
            };

            return barbershops;
        }
    }
}
