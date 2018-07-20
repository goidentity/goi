using GoIdentity.Entities.Core;
using GoIdentity.Web.App;
using GoIdentity.Web.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GoIdentity.Web.Controllers
{
    [Route("api/[controller]")]
    [GoIdentityExceptionFilter]
    public class TokenController : BaseController
    {
        private ITokenProvider _tokenProvider;

        public TokenController(UserContext userContext, ITokenProvider tokenProvider) // We'll create this later, don't worry.
        {
            this.userContext = userContext;
            _tokenProvider = tokenProvider;
        }

        [Route("[action]")]
        [AllowAnonymous]
        [HttpPost]
        public JsonWebToken Generate([FromBody] LoginViewModel model)
        {
            int ageInMinutes = 60;
            DateTime expiry = DateTime.UtcNow.AddMinutes(ageInMinutes);

            return _tokenProvider.CreateToken(0
                , model.username.IndexOf(":") > -1 ? model.username.Split(':')[0] : model.username
                , model.username.IndexOf(":") > -1 ? model.username.Split(':')[1] : model.username
                , model.password, expiry);
        }

        [Route("[action]")]
        [HttpPost]
        [Authorize]
        public JsonWebToken Refresh()
        {
            int ageInMinutes = 60;
            DateTime expiry = DateTime.UtcNow.AddMinutes(ageInMinutes);

            return _tokenProvider.CreateToken(int.Parse(this.User.Claims.First(c => c.Type == "UserId").Value), "", "", "", expiry);
        }
    }

    public class LoginViewModel
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
