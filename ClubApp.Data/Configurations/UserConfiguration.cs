using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubApp.Data.Entities;

namespace ClubApp.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.Property(user => user.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(user => user.Email)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(user => user.IsVerified)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(user => user.UserAttribute)
                .WithOne(attribute => attribute.User)
                .HasForeignKey<UserAttribute>(attribute => attribute.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(user => user.UserInvitation)
                .WithOne(invitation => invitation.User)
                .HasForeignKey<UserInvitation>(invitation => invitation.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(user => user.Email)
                .IsUnique();
        }
    }
}
