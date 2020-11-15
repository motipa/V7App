using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubApp.Data.Entities;

namespace ClubApp.Data.Configurations
{
    public class ApiClientConfiguration : IEntityTypeConfiguration<ApiClient>
    {
        public void Configure(EntityTypeBuilder<ApiClient> builder)
        {
            builder.ToTable(nameof(ApiClient));

            builder.Property(apiClient => apiClient.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(apiClient => apiClient.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(apiClient => apiClient.Secret)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(apiClient => apiClient.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(apiClient => apiClient.IsSecured)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(apiClient => apiClient.AccessTokenLifeTimeMin)
                .IsRequired();

            builder.Property(apiClient => apiClient.RefreshTokenLifeTimeMin)
                .IsRequired();

            builder.HasIndex(apiClient => apiClient.Name)
                .IsUnique();

            builder.HasIndex(apiClient => apiClient.Secret)
                .IsUnique();
        }
    }
}
