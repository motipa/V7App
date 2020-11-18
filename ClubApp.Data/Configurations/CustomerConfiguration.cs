using ClubApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.Property(attribute => attribute.Id)
                .HasDefaultValueSql("newsequentialid()");
            builder.Property(attribute => attribute.Name)
               .HasMaxLength(64)
               .IsRequired(); 
            builder.Property(attribute => attribute.Email)
               .HasMaxLength(64)
               .IsRequired();
            builder.Property(attribute => attribute.Phone)
               .HasMaxLength(64)
               .IsRequired();
            builder.Property(attribute => attribute.VIP).HasDefaultValue(false);
        }
    }
}
