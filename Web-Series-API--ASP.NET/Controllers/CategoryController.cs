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
    [VideoManagerChecker]
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {
        [Route("api/categories")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, CategoryService.Get());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error no categories found", e);
            }
        }
        [Route("api/category/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, CategoryService.Get(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error category not found", e);
            }
        }

        [Route("api/category/create")]
        [HttpPost]
        public HttpResponseMessage Post(CategoryModel cat)
        {
            try
            {
                CategoryService.Create(cat);
                return Request.CreateResponse(HttpStatusCode.Created, "Category inserted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding Category", e);
            }
        }

        [Route("api/category/edit")]
        [HttpPut]
        public HttpResponseMessage Put(CategoryModel cat)
        {
            try
            {
                CategoryService.Update(cat);
                return Request.CreateResponse(HttpStatusCode.OK, "category updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating category", e);
            }
        }

        [Route("api/category/remove/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                CategoryService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Created, "category remove successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error removing category", e);
            }
        }
    }
}
