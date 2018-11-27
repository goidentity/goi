using GoIdentity.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.ResourceAccess.Contracts.Core
{
    public interface IScoreDataAccess
    {
        List<vUserScore> GetLatestScoreByUserId(int userId);
        List<UserNotification> GetNotifications(int userId);
        List<ProfileScore> GetProfileScore(int userId);
    }
}
