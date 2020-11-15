using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubApp.Data.Entities;

namespace ClubApp.Data.Configurations
{
    public class ApiRefreshTokenConfiguration : IEntityTypeConfiguration<ApiRefreshToken>
    {
        public void Configure(EntityTypeBuilder<ApiRefreshToken> builder)
        {
            builder.ToTable(nameof(ApiRefreshToken));

            builder.Property(token => token.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(token => token.IssuedAt)
                .IsRequired();

            builder.Property(token => token.ExpiresAt)
                .IsRequired();

            builder.Property(token => token.Value)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasOne(token => token.ApiClient)
                  .WithMany(client => client.ApiRefreshTokens)
                  .HasForeignKey(token => token.ApiClientId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(token => token.Value)
                .IsUnique();

           
        }
    }
}
