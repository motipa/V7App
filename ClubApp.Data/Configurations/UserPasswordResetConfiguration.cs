using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubApp.Data.Entities;

namespace ClubApp.Data.Configurations
{
  public  class UserPasswordResetConfiguration : IEntityTypeConfiguration<UserPasswordReset>
    {
        public void Configure(EntityTypeBuilder<UserPasswordReset> builder)
        {
            builder.ToTable(nameof(UserPasswordReset));

            builder.Property(reset => reset.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(reset => reset.RequestedAt)
                .IsRequired();

            builder.Property(reset => reset.ExpiresAt)
                .IsRequired();

            builder.Property(reset => reset.Value)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(reset => reset.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(reset => reset.IsCompleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(reset => reset.User)
                .WithMany(user => user.UserPasswordResets)
                .HasForeignKey(reset => reset.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(reset => reset.Value)
                .IsUnique();
        }
    }
}
