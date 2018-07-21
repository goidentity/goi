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
        public User Register([FromBody]RegisterViewModel registerViewModel)
        {
            var user = new User()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.EmailId,
                MobileNumber = registerViewModel.MobileNumber,
                AccountType = AccountType.Individual
            };

            return userBusinessAccess.Register(user, registerViewModel.Password);
        }
    }
}
