using GoIdentity.Entities.Core;
using GoIdentity.ResourceAccess.Contracts.Core;
using System;
using System.Collections.Generic;
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

        public List<vUserScore> GetLatestScoreByUserId(int userId)
        {
            var result = this.unitOfWork.GetIdentityDbContext().ExecuteResultSet<vUserScore>("select * from Core.vUserScore where UserId = " + userId.ToString()).ToList();
            return result;
        }

        public void GetUserScore(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
