using GoIdentity.BusinessAccess.Contracts.Core;
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

    }
}
