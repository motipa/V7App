using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubApp.Data.Entities;

namespace ClubApp.Data.Configurations
{
    public class UserTenantApplicationRoleConfiguration : IEntityTypeConfiguration<UserTenantApplicationRole>
    {
        public void Configure(EntityTypeBuilder<UserTenantApplicationRole> builder)
        {
            builder.ToTable(nameof(UserTenantApplicationRole));

            builder.Property(join => join.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(join => join.IsEnabled)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(join => join.User)
                .WithMany(user => user.UserTenantApplicationRoles)
                .HasForeignKey(join => join.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

          

            builder.HasIndex(join => new { join.UserId, join.TenantId, join.ApplicationId })
                .IsUnique();
        }
    }
}
