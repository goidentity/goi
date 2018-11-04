using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Entities.Core;
using GoIdentity.Web.App;
using GoIdentity.Web.App.ServiceEntites;
using GoIdentity.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GoIdentity.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [GoIdentityExceptionFilter]
    public class UserApiController : BaseController
    {
        private IUserBusinessAccess userBusinessAccess = default(IUserBusinessAccess);

        public UserApiController(UserContext userContext, IUserBusinessAccess userBusinessAccess) 
        {
            this.userContext = userContext;
            this.userBusinessAccess = userBusinessAccess;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetNavigationItems()
        {
            var loggedInUserId = this.LoggedInUserId;
            return Ok(this.userBusinessAccess.GetNavigationItems(loggedInUserId));
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]RegisterViewModel registerViewModel)
        {
            var user = new User()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.EmailId,
                MobileNumber = registerViewModel.MobileNumber,
                AccountType = AccountType.Individual
            };

            return Ok(userBusinessAccess.Register(user, registerViewModel.Password));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetUserProfile()
        {
            var loggedInUserId = this.LoggedInUserId;
            return Ok(this.userBusinessAccess.GetUserProfile(loggedInUserId));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetMyUserProfile()
        {
            var loggedInUserId = this.LoggedInUserId;
            return Ok(this.userBusinessAccess.GetMyUserProfile(loggedInUserId));
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public int CreateUserProfile([FromBody]UserProfileViewModel userProfileViewmodel)
        {
            var loggedInUserId = this.LoggedInUserId;
            var userProfile = new UserProfile()
            {
                DOB = userProfileViewmodel.DOB,
                Area = userProfileViewmodel.Area,
                Gender = userProfileViewmodel.Gender,
                Profession = userProfileViewmodel.Profession,
                RolesPlayed = userProfileViewmodel.RolesPlayed,
                RolesInterested = userProfileViewmodel.RolesInterested,
                UserId = loggedInUserId
            };

            return userBusinessAccess.CreateUserProfile(userProfile);
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public int UpdateUserProfile([FromBody]UserProfileViewModel userProfileViewmodel)
        {
            var loggedInUserId = this.LoggedInUserId;
            var userProfile = new UserProfile()
            {
                DOB = userProfileViewmodel.DOB,
                Area = userProfileViewmodel.Area,
                Gender = userProfileViewmodel.Gender,
                Profession = userProfileViewmodel.Profession,
                RolesPlayed = userProfileViewmodel.RolesPlayed,
                RolesInterested = userProfileViewmodel.RolesInterested,
                UserId = loggedInUserId
            };

            return userBusinessAccess.UpdateUserProfile(userProfile);
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public int UpdateMyUserProfile([FromBody]MyUserProfile userProfile)
        {
            var loggedInUserId = this.LoggedInUserId;           
            return userBusinessAccess.UpdateMyUserProfile(userProfile);
        }

        [Route("[action]")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword(string userName)
        {
            return Ok(true);
        }
    }
}
