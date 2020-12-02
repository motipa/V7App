using ClubApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Data.Configurations
{
    public class BookingDetailsConfiguration : IEntityTypeConfiguration<TableBookingDetails>
    {
        public void Configure(EntityTypeBuilder<TableBookingDetails> builder)
        {
            builder.ToTable(nameof(TableBookingDetails));

            builder.Property(attribute => attribute.Id)
                .HasDefaultValueSql("newsequentialid()");
            builder.Property(attribute => attribute.BookingDateTimeFrom).IsRequired();
            builder.Property(attribute => attribute.BookingDateTimeTo).IsRequired();
            builder.Property(attribute => attribute.TableNum).IsRequired();
            builder.Property(attribute => attribute.PaymentStatus).HasMaxLength(20).HasDefaultValue("PENDING")
                .IsRequired();
            builder.Property(attribute => attribute.CreateDate).HasDefaultValue(DateTime.Now);

        }
    }
}
