using GoIdentity.Entities.Core;
using GoIdentity.Entities.Security;
using GoIdentity.ResourceAccess.Contracts.Core;
using GoIdentity.Utilities.Constants;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GoIdentity.ResourceAccess.Implementation.Core
{
    public class UserDataAccess : DataAccess, IUserDataAccess
    {
        public UserDataAccess(UserContext userContext, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<Claim> ValidateUser(UserLoginLog userLoginLog, out User user)
        {
            var result = default(List<Claim>);
            user = default(User);

#if DEBUG
            if (userLoginLog.HostName == "localhost") userLoginLog.HostName = DevConstants.Dev_Host_Name;
#endif

            var primaryDbContext = this.unitOfWork.GetIdentityDbContext();
            var parmsCollection = new ParmsCollection();
            result = primaryDbContext.ExecuteStoredProcedure<Claim>("[Core].[validateUserCredentials]",
                parmsCollection
                    .AddParm("@userId", SqlDbType.Int, userLoginLog.UserId)
                    .AddParm("@userName", SqlDbType.VarChar, userLoginLog.UserName)
                    .AddParm("@password", SqlDbType.VarChar, userLoginLog.Password)
                    .AddParm("@remoteIpAddress", SqlDbType.VarChar, userLoginLog.RemoteIPAddress)
                    .AddParm("@localIpAddress", SqlDbType.VarChar, userLoginLog.LocalIPAddress)
                    .AddParm("@appKey", SqlDbType.VarChar, userLoginLog.AppKey)
                ).ToList();

            if (result.Any(r => r.ClaimType == "UserId"))
            {
                var userId = int.Parse(result.First(r => r.ClaimType == "UserId").ClaimValue);
                user = primaryDbContext.Users.First(emp => emp.UserId == userId);
            }

            return result;
        }
        public User Register(User user, string password)
        {
            var primaryDbContext = this.unitOfWork.GetIdentityDbContext();
            return new User();
        }
    }
}
