﻿using GoIdentity.Entities.Core;
using GoIdentity.Entities.Security;
using GoIdentity.ResourceAccess.Contracts.Core;
using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Utilities.Security;
using System.Collections.Generic;

namespace GoIdentity.BusinessAccess.Contracts.Core
{
    public interface IUserBusinessAccess
    {
        List<Claim> ValidateUser(UserLoginLog userLoginLog, out User user);
<<<<<<< HEAD
        User Register(User user, string password);
=======
        List<Navigation> GetNavigationItems(int? userId = null);
>>>>>>> 4b707ba8a386cbeb10123eb4eb67351c2d2de9a6
    }
}
