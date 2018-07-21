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
            var parmsCollection = new ParmsCollection();
            if (userId.HasValue)
            {
                var result = this.unitOfWork.GetIdentityDbContext().ExecuteStoredProcedure<UserProfile>("[Core].[getUserProfile]", parmsCollection.AddParm("@userId", SqlDbType.Int, userId));                                

                return result.ToList().FirstOrDefault();
            }
            else
            {
                return this.unitOfWork.GetIdentityDbContext().UserProfile.FirstOrDefault();
            }
        }
        public int CreateUserProfile(UserProfile userProfile)
        { 
            var primaryDbContext = this.unitOfWork.GetIdentityDbContext();
            var parmsCollection = new ParmsCollection();
            var result = primaryDbContext.ExecuteNonQuery("[Core].[createUserProfile]",
                parmsCollection
                    .AddParm("@dob", SqlDbType.VarChar, userProfile.DOB)
                    .AddParm("@area", SqlDbType.VarChar, userProfile.Area)
                    .AddParm("@gender", SqlDbType.VarChar, userProfile.Gender)
                    .AddParm("@profession", SqlDbType.VarChar, userProfile.Profession)
                    .AddParm("@rolesplayed", SqlDbType.VarChar, userProfile.RolesPlayed)
                    .AddParm("@rolesinterested", SqlDbType.VarChar, userProfile.RolesInterested)
                    .AddParm("@userId", SqlDbType.Int, userProfile.UserId),CommandType.StoredProcedure
                );          

            return result;
        }
        public int UpdateUserProfile(UserProfile userProfile)
        {
            var primaryDbContext = this.unitOfWork.GetIdentityDbContext();
            var parmsCollection = new ParmsCollection();
            var result = primaryDbContext.ExecuteNonQuery("[Core].[updateUserProfile]",
                parmsCollection
                    .AddParm("@dob", SqlDbType.VarChar, userProfile.DOB)
                    .AddParm("@area", SqlDbType.VarChar, userProfile.Area)
                    .AddParm("@gender", SqlDbType.VarChar, userProfile.Gender)
                    .AddParm("@profession", SqlDbType.VarChar, userProfile.Profession)
                    .AddParm("@rolesplayed", SqlDbType.VarChar, userProfile.RolesPlayed)
                    .AddParm("@rolesinterested", SqlDbType.VarChar, userProfile.RolesInterested)
                    .AddParm("@userId", SqlDbType.Int, userProfile.UserId)
                );
            return result;
        }

    }
}
