﻿using BusinessEntityLayer;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Web_Series_API__ASP.NET.Auth;

namespace Web_Series_API__ASP.NET.Controllers
{
    [EnableCors("*", "*", "*")]
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
                    var  token =AuthService.Authenticate(login);
                    
                    return Request.CreateResponse(HttpStatusCode.OK, token.TokenData);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Please provide valid credentials");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error user not login", e);
            }
        }

        [TokenChecker]
        [Route("api/logout")]
        [HttpPost]
        public HttpResponseMessage Logout()
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                if (token != null)
                {
                    AuthService.Logout(token);
                    return Request.CreateResponse(HttpStatusCode.Created, "User logout successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error user not logout");
 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error user not logout", e);
            }
        }
    }
}
