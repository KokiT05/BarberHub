using BarberHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Data.Configuration
{
    using static Common.EntityConstants.OfferConstants;
    using static Common.EntityConstants;
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> model)
        {
            model.HasKey(o => o.Id);

            model.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            model.Property(o => o.Description)
                .HasMaxLength(DescriptionMaxLength);

            model.Property(o => o.Price)
                .IsRequired()
                .HasPrecision(3, 2)
                .HasMaxLength(PriceMaxValue);

            model.HasOne(o => o.Barbershop)
                .WithMany(b => b.Offers)
                .HasForeignKey(o => o.BarbershopId)
                .OnDelete(DeleteBehavior.Restrict);

            model.HasData(this.SeedOffers());
        }

        private List<Offer> SeedOffers()
        {
            List<Offer> offers = new List<Offer>()
            {
                new Offer()
                {
                    Id = Guid.Parse("99242240c9e942ff84148536eb740c84"),
                    Name = "Подстригване с един номер",
                    Description = "Минаване с машина за подстригване по цялата глава с един номер",
                    Price = 5
                },
                new Offer()
                {
                    Id = Guid.Parse("6582820a79c54ecf853d544b64f528ed"),
                    Name = "Оформяне на вежди",
                    Description = "Оформяне на вежди",
                    Price = 2
                },
                new Offer()
                {
                    Id = Guid.Parse("0d4de42af4b04e1aa6ee9df1ead44ff6"),
                    Name = "Оформяне на брада",
                    Description = "Добре оформена брада с бръснач",
                    Price = 3
                }
            };

            return offers;
        }
    }
}
