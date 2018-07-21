using GoIdentity.BusinessAccess.Contracts.Core;
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
        private readonly IScoreDataAccess _scoreDataAccess;
        public ScoreBusinessAccess(IScoreDataAccess scoreDataAccess)
        {
            _scoreDataAccess = scoreDataAccess;
        }

        public void GetUserScore(int userId)
        {
            _scoreDataAccess.GetUserScore(userId);
        }
    }
}
