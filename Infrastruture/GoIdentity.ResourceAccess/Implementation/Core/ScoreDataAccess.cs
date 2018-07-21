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
            return this.unitOfWork.GetIdentityDbContext().vUserScores.Where(u => u.UserId == userId).ToList();
        }

        public void GetUserScore(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
