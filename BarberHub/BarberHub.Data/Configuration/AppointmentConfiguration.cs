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
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> model)
        {
            model.HasKey(a => a.Id);

            model.Property(a => a.Description)
                .IsRequired();

            model.Property(a => a.Comment)
                .IsRequired(false);

            model.Property(a => a.TotalPrice)
                .HasPrecision(5, 2)
                .IsRequired();

            model.HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId);

            model.HasOne(a => a.Barbershop)
                .WithMany(b => b.Appointments)
                .HasForeignKey(a => a.BarbershopId);

            model.HasQueryFilter(a => a.IsActive == true);
        }
    }
}
