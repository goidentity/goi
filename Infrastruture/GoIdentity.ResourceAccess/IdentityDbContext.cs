using GoIdentity.Entities.Core;
using GoIdentity.Utilities.Constants;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GoIdentity.ResourceAccess
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext()
            : base(ConnectionStrings.COMMON_CONNECTION_STRING)
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            Database.SetInitializer<IdentityDbContext>(null);
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = ConnectionStrings.COMMAND_TIMEOUT;
        }
        
        #region Core
        public DbSet<User> Users { get; set; }
        public DbSet<Navigation> Navigations { get; set; }
        #endregion

    }
}
