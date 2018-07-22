using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoIdentity.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoIdentity.Web.App.Controllers
{
    [Route("api/oauth")]
    [GoIdentityExceptionFilter]
    public class OAuthDataApiController : BaseController
    {
        public OAuthDataApiController()
        {

        }
        [AllowAnonymous]
        [HttpGet]
        [Route("linkedin/callback")]
        public IActionResult LinkedInCallback(string code, string state)
        {
            return Redirect(@"http://localhost:53106/#/ops/contactus");
        }
        [HttpGet]
        [Route("url")]
        public IActionResult GetAuthUrl()
        {
            
            return Ok(new
            {
                Url = @"https://www.linkedin.com/oauth/v2/authorization?" +
                           "response_type=code&" +
                           "client_id=819u32abc5qgqk&" +
                           "redirect_uri=http%3A%2F%2Flocalhost%3A53106%2Fapi%2Foauth%2Flinkedin%2Fcallback&" +
                           "state=987654321&" +
                           "scope=r_basicprofile"
            });
        }
    }
}
