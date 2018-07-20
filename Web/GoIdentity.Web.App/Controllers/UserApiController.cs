﻿using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Entities.Core;
using GoIdentity.Web.App;
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
        
    }
}
