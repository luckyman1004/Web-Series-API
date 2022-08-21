using BusinessEntityLayer;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_Series_API__ASP.NET.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                if (AuthService.EmailCheck(login.Email) != null)
                {
                    AuthService.Authenticate(login);
                    return Request.CreateResponse(HttpStatusCode.OK, "User login successfully");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Please provide valid credentials");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error user not login", e);
            }
        }
    }
}
