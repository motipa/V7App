using ClubApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Data.Configurations
{
    public class PaymentDetailsConfiguration : IEntityTypeConfiguration<PaymentDetails>
    {
        public void Configure(EntityTypeBuilder<PaymentDetails> builder)
        {
            builder.ToTable(nameof(PaymentDetails));
            builder.Property(property => property.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(property => property.Amount).IsRequired();
            builder.Property(property => property.PaymentReferenceId).IsRequired();
            builder.Property(property => property.BookingId).IsRequired();
            builder.Property(property => property.CustId).IsRequired();
            builder.Property(property => property.Status).HasMaxLength(25).IsRequired();
        }
    }
}
