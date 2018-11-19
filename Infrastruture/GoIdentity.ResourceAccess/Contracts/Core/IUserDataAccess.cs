using GoIdentity.Entities.Core;
using GoIdentity.Entities.Security;
using System.Collections.Generic;

namespace GoIdentity.ResourceAccess.Contracts.Core
{
    public interface IUserDataAccess
    {
        List<Claim> ValidateUser(UserLoginLog userLoginLog, out User user);
        User Register(User user, string password);
        List<Navigation> GetNavigationItems(int? userId = null);

        User GetUserProfile(int? userId = null);
        List<UserScore> GetUserScores(int? userId = null);

        bool UpdateUserProfile(User user);
    }
}
