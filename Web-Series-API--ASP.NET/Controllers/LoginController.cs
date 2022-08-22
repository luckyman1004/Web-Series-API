using BusinessEntityLayer;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Web_Series_API__ASP.NET.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LoginController : ApiController
    {
        [Route("api/sign-up")]
        [HttpPost]
        public HttpResponseMessage Post(LoginModel login)
        {
            try
            {
                if (AuthService.EmailCheck(login.Email) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Email is already registered");
                }
                LoginService.Create(login);
                return Request.CreateResponse(HttpStatusCode.Created, "User registered successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error register user", e);
            }
        }
    }
}
