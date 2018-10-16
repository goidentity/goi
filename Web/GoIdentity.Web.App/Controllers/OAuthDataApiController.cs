using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facebook;
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
        string _appAccessToken;
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
        [Route("linkedin")]
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
        public IActionResult FacebookCallback(dynamic authModel)
        {
            string appId = "557746184671124",
                   appSecret = "236104e44d3f8b702102ec87ba67f4aa";
            var client = new FacebookClient
            {
                AppId = appId,
                AppSecret = appSecret,
            };
            AuthorizeUser(client, authModel.id, authModel.access_token);
            return Ok();
        }

        [HttpGet]
        [Route("facebook")]
        public IActionResult FacebookUrl()
        {
            string appId = "557746184671124",
                   appSecret = "236104e44d3f8b702102ec87ba67f4aa";
            var state = "987654321";
            var client = new FacebookClient
            {
                AppId = appId, 
                AppSecret = appSecret, 
            };

            dynamic appTokenQueryResponse = client.Get("oauth/access_token"
                                                        , new
                                                        {
                                                            client_id = appId,
                                                            client_secret = appSecret,
                                                            grant_type = "client_credentials"
                                                        });

            _appAccessToken = appTokenQueryResponse.access_token;
            return Ok(new
            {
                Url = @"https://www.facebook.com/v3.1/dialog/oauth?" +
                           "client_id=" + appId +
                           "&scope=public_profile,email" +
                          // "&display=popup" +
                           "&response_type=token" +
                           "&redirect_uri= " + "https%3A%2F%2Flocalhost%3A44344%2Fapi%2Foauth%2Ffacebook%2Fcallback" + //+ $"https://localhost:44344/api/oauth/facebook/callback" +
                           "&state=" + state
                           
            });
        }

        public class FacebookAuthorizationResponse
        {
            public bool IsAuthorized { get; set; }
            public DateTime ExpiresAt { get; set; }
            public string Name { get; set; }
        }

        private FacebookAuthorizationResponse AuthorizeUser(FacebookClient client, string userId, string accessToken)
        {
            dynamic expirationToken = client.Get("debug_token", new
            {
                input_token = accessToken,
                access_token = _appAccessToken
            });

            DateTime expiresAt = DateTimeConvertor.FromUnixTime(expirationToken.data.expires_at);
            bool isValid = expirationToken.data.is_valid;

            if (!isValid)
            {
                return new FacebookAuthorizationResponse
                {
                    IsAuthorized = false,
                };
            }

            dynamic response = client.Get("me", new
            {
                access_token = accessToken,
                fields = "id,name"
            });

            return new FacebookAuthorizationResponse
            {
                IsAuthorized = isValid,
                ExpiresAt = expiresAt,
                Name = response.name
            };
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
