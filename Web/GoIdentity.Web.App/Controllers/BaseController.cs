using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Entities.Core;
using GoIdentity.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GoIdentity.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected UserContext userContext = default(UserContext);

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                var timezoneOffset = default(short);
                
                if (this.Request.Headers["TimezoneOffset"].Any())
                {
                    short.TryParse(this.Request.Headers["TimezoneOffset"].First(), out timezoneOffset);
                }

                userContext.TimezoneOffset = timezoneOffset;
                userContext.LoggedInUserId = this.LoggedInUserId;
            }
        }

        public IEnumerable<Claim> Claims
        {
            get
            {
                if (this.User == null) return null;
                else return this.User.Claims;
            }
        }

        public int LoggedInUserId { get { return int.Parse(this.Claims.First(c => c.Type == "UserId").Value); } }
        public string LoggedInUserName { get { return this.Claims.First(c => c.Type == "UserName").Value; } }
        
    }
}
