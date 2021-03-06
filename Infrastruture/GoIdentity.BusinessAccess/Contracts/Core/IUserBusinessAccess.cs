﻿using GoIdentity.Entities.Core;
using GoIdentity.Entities.Security;
using GoIdentity.ResourceAccess.Contracts.Core;
using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Utilities.Security;
using System.Collections.Generic;
using GoIdentity.Entities.Scores;

namespace GoIdentity.BusinessAccess.Contracts.Core
{
    public interface IUserBusinessAccess
    {
        List<Claim> ValidateUser(UserLoginLog userLoginLog, out User user);

        User Register(User user, string password);

        List<Navigation> GetNavigationItems(int? userId = null);

        User GetUserProfile(int? userId = null);
        List<UserScore> GetUserScores(int? userId = null);
        bool UpdateUserProfile(User user);
        UserIdentity GetUserIdentity(int userId);
    }
}
