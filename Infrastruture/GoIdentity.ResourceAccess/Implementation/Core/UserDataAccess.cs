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

        public List<Navigation> GetNavigationItems(int? userId = null)
        {
            if (userId.HasValue)
            {
                var parmsCollection = new ParmsCollection();

                var result = this.unitOfWork.GetIdentityDbContext().ExecuteStoredProcedure<Navigation>
                                ("[Core].[getNavigationItemsByUserId]",
                                    parmsCollection
                                    .AddParm("@userId", SqlDbType.Int, userId)).ToList();

                //TODO: check this
                return result.ToList();
            }
            else
            {
                return this.unitOfWork.GetIdentityDbContext().Navigations.ToList();
            }
        }

        public UserProfile GetUserProfile(int? userId = null)
        {
            if (userId.HasValue)
            {
                var result = this.unitOfWork.GetIdentityDbContext().ExecuteQuery
                                ("Select * from [Core].[UserProfile] where UserId=" + @userId);

                return result;
            }
            else
            {
                return this.unitOfWork.GetIdentityDbContext().UserProfile;
            }
        }
        public int CreateUserProfile(UserProfile userProfile)
        {

        }
        public int UpdateUserProfile(int? userId = null)
        {

        }

    }
}
