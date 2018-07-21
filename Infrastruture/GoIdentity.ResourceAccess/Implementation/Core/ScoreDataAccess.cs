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
        public ScoreDataAccess(IUnitOfWork unitOfWork, Entities.Core.UserContext userContext = null) : base(unitOfWork, userContext)
        {
        }

        public void GetUserScore(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
