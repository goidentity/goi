using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Entities.Core;
using GoIdentity.ResourceAccess.Contracts.Core;
using System.Collections.Generic;
using System.Linq;

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
            var scores = this.scoreDataAccess.GetLatestScoreByUserId(userId);
            foreach(vUserScore score in scores.Where(s=>s.ScoreType =="CurrentScore"))
            {
                var lastScore = scores.FirstOrDefault(s => s.IndustryId == score.IndustryId &&
                                                             s.CategoryId == score.CategoryId &&
                                                             s.ScoreType == "LastScore");
                score.LastScore = (lastScore!= null)? lastScore.Score: 0;
            }
            return scores.Where(s => s.ScoreType == "CurrentScore").ToList();
        }

        public List<UserNotification> GetNotifications(int userId)
        {
            return this.scoreDataAccess.GetNotifications(userId);
        }

        public List<ProfileScore> GetProfileScore(int userId)
        {
            return this.scoreDataAccess.GetProfileScore(userId);
        }
    }
}
