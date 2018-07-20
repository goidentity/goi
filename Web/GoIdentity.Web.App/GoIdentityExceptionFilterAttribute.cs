using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace GoIdentity.Web.App
{
    public class GoIdentityExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private ILogger<GoIdentityExceptionFilterAttribute> log;

        public override void OnException(ExceptionContext context)
        {
            log = GoIdentity.DIContainer.ServiceLocator.Instance.Get<ILogger<GoIdentityExceptionFilterAttribute>>();

            var errorMessage = context.Exception.GetBaseException().Message;
            log.LogError(context.Exception, errorMessage);

            var apiError = new ApplicationException(errorMessage, context.Exception);
            context.HttpContext.Response.StatusCode = 500;

            context.Result = new JsonResult(apiError);

            //var telemetry = new TelemetryClient();
            //telemetry.TrackException(context.Exception);

            base.OnException(context);
        }
    }
}
