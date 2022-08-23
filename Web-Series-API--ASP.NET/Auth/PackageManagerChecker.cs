using BusinessLogicLayer.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Web_Series_API__ASP.NET.Auth
{
    public class PackageManagerChecker :AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var header = actionContext.Request.Headers.Authorization;
            if (header == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,"Token not found, can't find role");
            }
            else
            {
                if (TokenService.GetLoginByToken(header.ToString()).Equals("PackageManager"))
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
