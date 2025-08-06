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
    public class SelectOfferConfiguration : IEntityTypeConfiguration<SelectOffer>
    {
        public void Configure(EntityTypeBuilder<SelectOffer> model)
        {
            model.HasKey(so => so.Id);

            model.Property(so => so.SelectOfferDescription)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            model.Property(so => so.TotalPrice)
                .IsRequired();

            model.Property(so => so.SelectedOn)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            model.Property(so => so.Comment)
                .HasMaxLength(CommentMaxLength);

            model.HasOne(so => so.User)
                .WithOne()
                .HasForeignKey<SelectOffer>(so => so.UserId)
                .IsRequired();

        }
    }
}
