
 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ClubApp.Data.Common;
using ClubApp.Data.Entities;
using ClubApp.Data.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClubApp.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        

        public DbSet<ApiClient> ApiClients { get; set; }

        public DbSet<ApiRefreshToken> ApiRefreshTokens { get; set; }

       
        public DbSet<User> Users { get; set; }

        public DbSet<UserAttribute> UserAttributes { get; set; }

        public DbSet<UserInvitation> UserInvitations { get; set; }

        public DbSet<UserPasswordReset> UserPasswordResets { get; set; }

        public DbSet<UserTenantApplicationRole> UserTenantApplicationRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurations(GetType().Assembly);     
        }

        //public override int SaveChanges()
        //{
        //    DoHardDeleteEntities();
        //    return base.SaveChanges();
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    DoHardDeleteEntities();
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        private void DoHardDeleteEntities()
        {
            IEnumerable<EntityEntry> entitiesToDelete = new List<EntityEntry>(ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted && e.Metadata.ClrType.IsSubclassOf(typeof(EntityBase))));

            foreach (EntityEntry entity in entitiesToDelete)
            {
                Database.ExecuteSqlRaw(string.Format("EXEC dbo.Delete{0} @{0}ID = '{1}'", entity.Metadata.ClrType.Name, entity.CurrentValues["Id"]));
                entity.State = EntityState.Detached;
            }
        }
    }
}
