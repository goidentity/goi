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
        UserProfile GetUserProfile(int? userId = null);

        MyUserProfile GetMyUserProfile(int? userId = null);
        int CreateUserProfile(UserProfile userProfile);
        int UpdateUserProfile(UserProfile userProfile);
        int UpdateMyUserProfile(MyUserProfile userProfile);

    }
}
