using GoIdentity.Entities.Core;
using GoIdentity.Entities.Security;
using System.Collections.Generic;

namespace GoIdentity.ResourceAccess.Contracts.Core
{
    public interface IUserDataAccess
    {
        List<Claim> ValidateUser(UserLoginLog userLoginLog, out User user);
        List<Navigation> GetNavigationItems(int? userId = null);
    }
}
