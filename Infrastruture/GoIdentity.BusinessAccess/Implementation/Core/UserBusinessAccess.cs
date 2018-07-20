using GoIdentity.Entities.Core;
using GoIdentity.Entities.Security;
using GoIdentity.ResourceAccess.Contracts.Core;
using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Utilities.Security;
using System.Collections.Generic;

namespace GoIdentity.BusinessAccess.Implementation.Core
{
    public class UserBusinessAccess : IUserBusinessAccess
    {
        private IUserDataAccess userDataAccess;

        public UserBusinessAccess(UserContext userContext, IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        public List<Claim> ValidateUser(UserLoginLog userLoginLog, out User user)
        {
            //userLoginLog.Password = EncryptionManager.Encrypt(userLoginLog.Password);
            return this.userDataAccess.ValidateUser(userLoginLog, out user);
        }
    }
}
