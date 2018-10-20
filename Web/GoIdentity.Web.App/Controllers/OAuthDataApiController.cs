using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Entities.Scores;
using GoIdentity.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoIdentity.Web.App.Controllers
{
    [Route("api/oauth")]
    [GoIdentityExceptionFilter]
    public class OAuthDataApiController : BaseController
    {
        private readonly IAuthBusinessAccess authBusinessAccess;

        public OAuthDataApiController(IAuthBusinessAccess authBusinessAccess)
        {
            this.authBusinessAccess = authBusinessAccess;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("linkedin/callback")]
        public async Task<IActionResult> LinkedInCallback(string code, string state)
        {
            //var clientId = "819u32abc5qgqk";
            //var clientSecret = "tZQKBFRtsAFmbXMA";
            ////get access token
            //var authUrl = "https://www.linkedin.com/oauth/v2/accessToken?" +
            //                "grant_type=authorization_code&" +
            //                "code={0}&" +
            //                "redirect_uri={1}&" +
            //                "client_id={2}&" +
            //                "client_secret={3}";
            //authUrl = string.Format(authUrl, code,
            //                                 "http%3A%2F%2Flocalhost%3A53106%2Fapi%2Foauth%2Flinkedin%2Fcallback",
            //                                 clientId,
            //                                 clientSecret);


            ////var request = new RestRequest(authUrl);
            ////var restClient = new RestClient(authUrl);
            ////var response = restClient.Get(request);

            //return Redirect(@"http://localhost:53106/#/ops/contactus");

            bool isSuccess = await authBusinessAccess.StoreAuthToken(code, ConnectorType.LinkedIn);
            return Redirect(@"https://localhost:44344/#/ops/connectors");
        }
        [HttpGet]
        [Route("linkedin")]
        public IActionResult GetAuthUrl()
        {
            //var clientId = "819u32abc5qgqk";
            //var state = "987654321";
            
            //return Ok(new
            //{
            //    Url = @"https://www.linkedin.com/oauth/v2/authorization?" +
            //               "response_type=code&" +
            //               "client_id="+ clientId + "&" +
            //               "redirect_uri=http%3A%2F%2Flocalhost%3A53106%2Fapi%2Foauth%2Flinkedin%2Fcallback&" +
            //               "state="+state+"&" +
            //               "scope=r_basicprofile"
            //});

            return Ok(new
            {
                Url = authBusinessAccess.AuthorizeUser(ConnectorType.LinkedIn)
            });
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("facebook/callback")]
        public async Task<IActionResult> FacebookCallback(string code)
        {
            bool isSuccess = await authBusinessAccess.StoreAuthToken(code, ConnectorType.Facebook);
            return Redirect(@"https://localhost:44344/#/ops/connectors");
        }

        [HttpGet]
        [Route("facebook")]
        public IActionResult FacebookUrl()
        {
            return Ok(new
            {
                Url = authBusinessAccess.AuthorizeUser(ConnectorType.Facebook)
            });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("twitter/callback")]
        public async Task<IActionResult> TwitterCallback(string code)
        {
            bool isSuccess = await authBusinessAccess.StoreAuthToken(code, ConnectorType.Twitter);
            return Redirect(@"https://localhost:44344/#/ops/connectors");
        }
        [HttpGet]
        [Route("twitter")]
        public IActionResult TwitterAuthUrl()
        {
            return Ok(new
            {
                Url = authBusinessAccess.AuthorizeUser(ConnectorType.Twitter)
            });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("googleplus/callback")]
        public async Task<IActionResult> GoogleCallback(string code)
        {
            bool isSuccess = await authBusinessAccess.StoreAuthToken(code, ConnectorType.Google);
            return Redirect(@"https://localhost:44344/#/ops/connectors");
        }

        [HttpGet]
        [Route("googleplus")]
        public IActionResult GoogleAuthUrl()
        {
            return Ok(new
            {
                Url = authBusinessAccess.AuthorizeUser(ConnectorType.Google)
            });
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
