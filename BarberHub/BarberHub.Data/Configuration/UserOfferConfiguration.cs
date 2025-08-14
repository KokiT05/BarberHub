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
    using static Common.EntityConstants;
    using static Common.EntityConstants.SelectOfferConstants;
    public class UserOfferConfiguration : IEntityTypeConfiguration<UserOffer>
    {
        public void Configure(EntityTypeBuilder<UserOffer> model)
        {
            model.HasKey(so => new { so.UserId, so.OfferId});

            //model.Property(so => so.Description)
            //    .IsRequired()
            //    .HasMaxLength(DescriptionMaxLength);

            //model.Property(so => so.TotalPrice)
            //    .IsRequired()
            //    .HasPrecision(5, 2);

            model.Property(so => so.SelectedOn)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            //model.Property(so => so.Comment)
            //    .HasMaxLength(CommentMaxLength);

            model.HasOne(so => so.User)
                .WithMany()
                .HasForeignKey(so => so.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            model.HasOne(so => so.Offer)
                .WithMany(o => o.UserOffers)
                .HasForeignKey(so => so.OfferId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
