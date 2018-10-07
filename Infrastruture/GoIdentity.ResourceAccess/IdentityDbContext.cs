using GoIdentity.Entities.Core;
using GoIdentity.Entities.Scores;
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
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<IndustryCategoryMap> IndustryCategoryMap { get; set; }
        public DbSet<UserScore> UserScores { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public DbSet<Influencer> Influencers { get; set; }
        public DbSet<UserInfluencerAuth> UserInfluencerAuths { get; set; }
        public DbSet<EngineLog> EngineLogs { get; set; }

        #endregion

    }
}
