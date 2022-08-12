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
    public class FeaturedVideoController : ApiController
    {
        [Route("api/featuredvideos")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, FeaturedVideoService.Get());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error no Featured Videos found", e);
            }
        }
        [Route("api/featuredvideo/{id}")]
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
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error Featured Videos not found", e);
            }
        }

        [Route("api/featuredvideo/create")]
        [HttpPost]
        public HttpResponseMessage Post(FeaturedVideoModel fvid)
        {
            try
            {
                FeaturedVideoService.Create(fvid);
                return Request.CreateResponse(HttpStatusCode.Created, "Featured Video inserted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding Featured Video", e);
            }
        }

        [Route("api/featuredvideo/edit")]
        [HttpPut]
        public HttpResponseMessage Put(FeaturedVideoModel fvid)
        {
            try
            {
                FeaturedVideoService.Update(fvid);
                return Request.CreateResponse(HttpStatusCode.OK, "Featured Video updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating Featured Video", e);
            }
        }

        [Route("api/featuredvideo/remove/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                FeaturedVideoService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Created, "Featured video remove successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error removing Featured Video", e);
            }
        }
    }
}
