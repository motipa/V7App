using ClubApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Data.Configurations
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable(nameof(Guest));
            builder.Property(property => property.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(property=>property.Gender).HasMaxLength(10).IsRequired();
        }
    }
}
