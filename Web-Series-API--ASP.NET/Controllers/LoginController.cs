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
    public class LoginController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                LoginService.Authenticate(login);
                return Request.CreateResponse(HttpStatusCode.OK, "User login successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error user not login", e);
            }
        }
        
        [Route("api/sign-up")]
        [HttpPost]
        public HttpResponseMessage Post(LoginModel login)
        {
            try
            {
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
