using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubApp.Data.Entities;

namespace ClubApp.Data.Configurations
{
  public  class UserAttributeConfiguration : IEntityTypeConfiguration<UserAttribute>
    {
        public void Configure(EntityTypeBuilder<UserAttribute> builder)
        {
            builder.ToTable(nameof(UserAttribute));

            builder.Property(attribute => attribute.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(attribute => attribute.FirstName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(attribute => attribute.LastName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(attribute => attribute.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(attribute => attribute.PasswordHash)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
