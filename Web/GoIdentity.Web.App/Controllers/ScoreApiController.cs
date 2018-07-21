﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoIdentity.Web.App.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [GoIdentityExceptionFilter]
    public class ScoreApiController : BaseController
    {
        private readonly IScoreBusinessAccess _scoreBusinessAccess;
        public ScoreApiController(IScoreBusinessAccess scoreBusinessAccess)
        {
            _scoreBusinessAccess = scoreBusinessAccess;
        }

        [Route("[action]/{userId:int}")]
        [HttpGet]
        public IActionResult GetLatestScoreByUserId(int userId)
        {
            return Ok(_scoreBusinessAccess.GetLatestScoreByUserId(userId));
        }
    }
}
