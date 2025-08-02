using BarberHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberHub.Data.Configuration
{
    using static Common.EntityConstants.Babershop;

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

            model.Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
