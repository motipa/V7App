using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubApp.Data.Entities;

namespace ClubApp.Data.Configurations
{
    public class UserInvitationConfiguration : IEntityTypeConfiguration<UserInvitation>
    {
        public void Configure(EntityTypeBuilder<UserInvitation> builder)
        {
            builder.ToTable(nameof(UserInvitation));

            builder.Property(invitation => invitation.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(invitation => invitation.Value)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(invitation => invitation.CreatedAt)
                .IsRequired();

            builder.Property(invitation => invitation.ExpiresAt)
                .IsRequired();

            builder.HasIndex(invitation => invitation.Value)
                .IsUnique();
        }
    }
}
