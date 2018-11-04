using GoIdentity.Entities.Core;
using GoIdentity.Entities.Scores;
using GoIdentity.Utilities.Constants;
using Microsoft.EntityFrameworkCore;

namespace GoIdentity.ResourceAccess
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext()
            : base(GetOptions(ConnectionStrings.COMMON_CONNECTION_STRING))
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            //Database.SetInitializer<CommonDbContext>(null);
            Database.SetCommandTimeout(ConnectionStrings.COMMAND_TIMEOUT);
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #region Core
        public DbSet<User> Users { get; set; }
        public DbSet<Navigation> Navigations { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<MyUserProfile> MyUserProfile { get; set; }

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
