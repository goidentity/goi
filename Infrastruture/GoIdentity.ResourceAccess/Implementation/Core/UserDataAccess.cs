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
            var userTypeTable = UserDefinedTableTypes.UserType;
            var userPersonnelInfoTypeTable = UserDefinedTableTypes.UserPersonnelInfoType;
            var userEducationTypeTable = UserDefinedTableTypes.UserEducationType;
            var userExperienceTypeTable = UserDefinedTableTypes.UserExperienceType;
            var userBusinessTypeTable = UserDefinedTableTypes.BusinessProfileType;

            userTypeTable.Rows.Add(new object[]
                {
                    user.UserId,
                    user.UserName,

                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.MobileNumber,

                    user.UniqueId,
                    user.JsonFeed
                });

            var parmsCollection = new ParmsCollection();
            var result = this.unitOfWork.GetIdentityDbContext(true).ExecuteStoredProcedure<User>("[Core].[createUser]",
                            parmsCollection
                            .AddParm("@user", SqlDbType.Structured, userTypeTable, "[Core].[UserType]")
                            .AddParm("@password", SqlDbType.VarChar, password)).FirstOrDefault();

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

        public User GetUserProfile(int? userId = null)
        {
            var result = this.unitOfWork.GetIdentityDbContext().Users.First(u => u.UserId == userId);
            result.PersonnelInfo = this.unitOfWork.GetIdentityDbContext().UserPersonnelInfos.FirstOrDefault(u => u.UserId == userId);
            result.Experience = this.unitOfWork.GetIdentityDbContext().UserExperiences.Where(u => u.UserId == userId).ToList();
            result.Education = this.unitOfWork.GetIdentityDbContext().UserEducations.Where(u => u.UserId == userId).ToList();

            if (result.PersonnelInfo == null) result.PersonnelInfo = new UserPersonnelInfo();

            return result;
        }

        public List<UserScore> GetUserScores(int? userId = null)
        {
            var scores = this.unitOfWork.GetIdentityDbContext().UserScores.Where(u => u.UserId == userId).ToList();
            return scores;
        }

        public bool UpdateUserProfile(User user)
        {
            var userTypeTable = UserDefinedTableTypes.UserType;
            var userPersonnelInfoTypeTable = UserDefinedTableTypes.UserPersonnelInfoType;
            var userEducationTypeTable = UserDefinedTableTypes.UserEducationType;
            var userExperienceTypeTable = UserDefinedTableTypes.UserExperienceType;
            var userBusinessProfileTypeTable = UserDefinedTableTypes.BusinessProfileType;

            userTypeTable.Rows.Add(new object[]
                {
                    user.UserId,
                    user.UserName,

                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.MobileNumber,

                    user.UniqueId,
                    user.JsonFeed
                });

            userPersonnelInfoTypeTable.Rows.Add(new object[]
                {
                    user.PersonnelInfo.UserPersonnelInfoId,
                    user.PersonnelInfo.UserId,
                    user.PersonnelInfo.DoB,

                    user.PersonnelInfo.Gender,
                    user.PersonnelInfo.PlaceOfBirth,
                    user.PersonnelInfo.CityOfLiving,

                    user.PersonnelInfo.CityOfWork,
                    user.PersonnelInfo.MaritalStatus,
                    user.PersonnelInfo.BirthOfOrigin,
                    user.PersonnelInfo.Nationality,
                    user.PersonnelInfo.Citizenship,
                    user.PersonnelInfo.PRStatus,

                    user.PersonnelInfo.PrimaryIndustryOfWork,
                    user.PersonnelInfo.SecondaryIndustryOfWork,

                    user.PersonnelInfo.PrimaryIndustryOfBusiness,
                    user.PersonnelInfo.SecondaryIndustryOfBusiness,

                    user.PersonnelInfo.FutureRole,
                    user.PersonnelInfo.FutureIndustryOfWork,
                    user.PersonnelInfo.FutureIndustryOfBusiness,

                });

            foreach (var item in user.Experience)
            {
                userExperienceTypeTable.Rows.Add(new object[]
                {
                    item.UserExperienceId,
                    item.UserId,

                    item.OrganizationName,
                    item.Designation,
                    item.Roles,

                    item.StartDate,
                    item.EndDate,
                    item.IsCurrent,
                    item.ReasonForChange
                });
            }

            foreach (var item in user.Education)
            {
                userEducationTypeTable.Rows.Add(new object[]
                {
                    item.UserEducationId,
                    item.UserId,

                    item.DegreeType,
                    item.Title,
                    item.UniversityOrBoard,

                    item.InstitutionOrBoard,
                    item.YearOfPass,
                    item.Specialization
                });
            }

            foreach (var item in user.BusinessData)
            {
                userBusinessProfileTypeTable.Rows.Add(new object[]
                {
                    item.BusinessProfileId,
                    item.UserId,

                    item.YearOfEstablishment,
                    item.ComponySize,
                    item.Role
                });
            }

            var parmsCollection = new ParmsCollection();
            var result = this.unitOfWork.GetIdentityDbContext(true).ExecuteStoredProcedure<User>("[Core].[updateUser]",
                            parmsCollection
                            .AddParm("@user", SqlDbType.Structured, userTypeTable, "[Core].[UserType]")
                            .AddParm("@userPersonnelInfo", SqlDbType.Structured, userPersonnelInfoTypeTable, "[Core].[UserPersonnelInfoType]")
                            .AddParm("@userExperience", SqlDbType.Structured, userExperienceTypeTable, "[Core].[UserExperienceType]")
                            .AddParm("@userEducation", SqlDbType.Structured, userEducationTypeTable, "[Core].[UserEducationType]")
                            .AddParm("@userBusiness", SqlDbType.Structured, userBusinessProfileTypeTable, "[Core].[BusinessProfileType]")
                            ).FirstOrDefault();

            return true;
        }
    }
}
