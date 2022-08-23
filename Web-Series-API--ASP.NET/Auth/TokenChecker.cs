using BusinessLogicLayer.Services;
using System.Web.Http.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Web_Series_API__ASP.NET.Auth
{
    public class TokenChecker :AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var header = actionContext.Request.Headers.Authorization;
            if (header == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,"Token not found");
            }
            else
            {
                if (AuthService.isAuthenticated((header.ToString())))
                {

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,"Token is not valid or expired");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}
