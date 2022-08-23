using BusinessEntityLayer;
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
    [TokenChecker]
    [AdminChecker]
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, UserService.Get());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error no user found", e);
            }
        }

        [Route("api/user/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, UserService.Get(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error user not found", e);
            }
        }
        
        [Route("api/user/create")]
        [HttpPost]
        public HttpResponseMessage Post(UserModel user)
        {
            try
            {
                UserService.Create(user);
                return Request.CreateResponse(HttpStatusCode.Created, "User added successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding user", e);
            }
        }

        [Route("api/user/edit")]
        [HttpPut]
        public HttpResponseMessage Put(UserModel user)
        {
            try
            {
                UserService.Update(user);
                return Request.CreateResponse(HttpStatusCode.OK, "User updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating user", e);
            }
        }
        
        [Route("api/user/remove/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                UserService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Created, "User remove successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error removing user", e);
            }
        }

    }
}
