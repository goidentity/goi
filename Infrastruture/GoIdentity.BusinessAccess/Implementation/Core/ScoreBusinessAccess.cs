using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Entities.Core;
using GoIdentity.ResourceAccess.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.BusinessAccess.Implementation.Core
{
    public class ScoreBusinessAccess : IScoreBusinessAccess
    {
        private readonly IScoreDataAccess scoreDataAccess;

        public ScoreBusinessAccess(IScoreDataAccess scoreDataAccess)
        {
            this.scoreDataAccess = scoreDataAccess;
        }

        public List<vUserScore> GetLatestScoreByUserId(int userId)
        {
            return this.scoreDataAccess.GetLatestScoreByUserId(userId);
        }

    }
}
