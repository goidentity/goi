using GoIdentity.Entities.Core;
using GoIdentity.ResourceAccess.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.ResourceAccess.Implementation.Core
{
    public class ScoreDataAccess : DataAccess, IScoreDataAccess
    {

        public ScoreDataAccess(IUnitOfWork unitOfWork, UserContext userContext) : base(unitOfWork, userContext)
        {
            this.unitOfWork = unitOfWork;
            this.userContext = userContext;
        }

        public List<vUserScore> GetLatestScoreByUserId(int userId) => unitOfWork
                .GetIdentityDbContext()
                .ExecuteResultSet<vUserScore>("select * from Core.vUserScore where UserId = " + userId.ToString())
                .ToList();

        public List<ProfileScore> GetProfileScore(int userId)
        {
            var parmsCollection = new ParmsCollection();
            var result = this.unitOfWork.GetIdentityDbContext(true).ExecuteStoredProcedure<ProfileScore>("[Scores].[getProfileScore]",
                            parmsCollection
                            .AddParm("@userId", SqlDbType.Int, userId)).ToList();

            return result;
        }       

        public List<UserNotification> GetNotifications(int userId)
        {
            return this.unitOfWork.GetIdentityDbContext().UserNotifications.Where(n => n.UserId == userId).ToList();
        }
    }
}
