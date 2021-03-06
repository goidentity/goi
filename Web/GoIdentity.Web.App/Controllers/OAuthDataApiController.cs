﻿using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Entities.Scores;
using GoIdentity.Utilities.Constants;
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
            bool isSuccess = await authBusinessAccess.StoreAuthToken(code, ConnectorType.LinkedIn, 1); //used LoggedInUserId instead of 1
            
            return Redirect($"{ConnectionStrings.REDIRECT_URL_DOMAIN}/#/ops/connectors");
        }
        [HttpGet]
        [Route("linkedin")]
        public IActionResult GetAuthUrl()
        {
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
            bool isSuccess = await authBusinessAccess.StoreAuthToken(code, ConnectorType.Facebook, 1);
            return Redirect($"{ConnectionStrings.REDIRECT_URL_DOMAIN}/#/ops/connectors");
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
            bool isSuccess = await authBusinessAccess.StoreAuthToken(code, ConnectorType.Twitter, 1);
            return Redirect($"{ConnectionStrings.REDIRECT_URL_DOMAIN}/#/ops/connectors");
        }
        [HttpGet]
        [Route("twitter")]
        public async Task<IActionResult> TwitterAuthUrl()
        {
            bool? isSuccess = await authBusinessAccess.StoreAuthToken(string.Empty, ConnectorType.Twitter, 1);
            return Redirect($"{ConnectionStrings.REDIRECT_URL_DOMAIN}/#/ops/connectors");
            //return Ok(new
            //{
            //    Url = authBusinessAccess.AuthorizeUser(ConnectorType.Twitter)
            //});
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("googleplus/callback")]
        public async Task<IActionResult> GoogleCallback(string code)
        {
            bool isSuccess = await authBusinessAccess.StoreAuthToken(code, ConnectorType.Google, 1);
            return Redirect($"{ConnectionStrings.REDIRECT_URL_DOMAIN}/#/ops/connectors");
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
