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
        private readonly IUserBusinessAccess _userBusinessAccess;
        public UserApiController(IUserBusinessAccess userBusinessAccess)
        {
            _userBusinessAccess = userBusinessAccess;
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

            return _userBusinessAccess.Register(user, registerViewModel.Password);
        }
    }
}
