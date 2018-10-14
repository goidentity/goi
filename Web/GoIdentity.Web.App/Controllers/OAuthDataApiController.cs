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
            var clientId = "819u32abc5qgqk";
            var clientSecret = "tZQKBFRtsAFmbXMA";
            //get access token
            var authUrl = "https://www.linkedin.com/oauth/v2/accessToken?" +
                            "grant_type=authorization_code&" +
                            "code={0}&" +
                            "redirect_uri={1}&" +
                            "client_id={2}&" +
                            "client_secret={3}";
            authUrl = string.Format(authUrl, code,
                                             "http%3A%2F%2Flocalhost%3A53106%2Fapi%2Foauth%2Flinkedin%2Fcallback",
                                             clientId,
                                             clientSecret);


            //var request = new RestRequest(authUrl);
            //var restClient = new RestClient(authUrl);
            //var response = restClient.Get(request);

            return Redirect(@"http://localhost:53106/#/ops/contactus");
        }
        [HttpGet]
        [Route("url")]
        public IActionResult GetAuthUrl()
        {
            var clientId = "819u32abc5qgqk";
            var state = "987654321";
            
            return Ok(new
            {
                Url = @"https://www.linkedin.com/oauth/v2/authorization?" +
                           "response_type=code&" +
                           "client_id="+ clientId + "&" +
                           "redirect_uri=http%3A%2F%2Flocalhost%3A53106%2Fapi%2Foauth%2Flinkedin%2Fcallback&" +
                           "state="+state+"&" +
                           "scope=r_basicprofile"
            });
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("facebook/callback")]
        public IActionResult FacebookCallback()
        {
            return Ok();
        }

        [HttpGet]
        [Route("facebook")]
        public IActionResult FacebookUrl()
        {
            return Ok();
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("twitter/callback")]
        public IActionResult TwitterCallback()
        {
            return Ok();
        }
        [HttpGet]
        [Route("twitter")]
        public IActionResult TwitterAuthUrl()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("googleplus/callback")]
        public IActionResult GoogleCallback()
        {
            return Ok();
        }

        [HttpGet]
        [Route("googleplus")]
        public IActionResult GoogleAuthUrl()
        {
            return Ok();
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("instagram/callback")]
        public IActionResult InstagramCallback()
        {
            return Ok();
        }
        [HttpGet]
        [Route("instagram")]
        public IActionResult IstagramAuthUrl()
        {
            return Ok();
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("pinterest/callback")]
        public IActionResult PinterestCallback()
        {
            return Ok();
        }
        [HttpGet]
        [Route("pinterest")]
        public IActionResult Pinterest()
        {
            return Ok();
        }
    }
}
