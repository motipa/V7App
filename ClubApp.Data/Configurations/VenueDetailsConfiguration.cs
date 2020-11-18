using ClubApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Data.Configurations
{
    public class VenueDetailsConfiguration : IEntityTypeConfiguration<VenueDetails>
    {
        public void Configure(EntityTypeBuilder<VenueDetails> builder)
        {
            builder.ToTable(nameof(VenueDetails));
            builder.Property(property => property.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(property => property.VenueName).HasMaxLength(64).IsRequired();
            builder.Property(property=>property.VenuePhone).HasMaxLength(15).IsRequired();
            builder.Property(property=>property.VenueLocation).HasMaxLength(64).IsRequired();
            
        }
    }
}
