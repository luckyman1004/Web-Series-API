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
    public class VideoController : ApiController
    {
        [Route("api/videos")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, VideoService.Get());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error no Videos found", e);
            }
        }
        [Route("api/videos/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, VideoService.Get(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error Video not found", e);
            }
        }

        [Route("api/videos/create")]
        [HttpPost]
        public HttpResponseMessage Post(VideoModel video)
        {
            try
            {
                VideoService.Create(video);
                return Request.CreateResponse(HttpStatusCode.Created, "Video inserted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding video", e);
            }
        }

        [Route("api/videos/edit")]
        [HttpPut]
        public HttpResponseMessage Put(VideoModel video)
        {
            try
            {
               VideoService.Update(video);
                return Request.CreateResponse(HttpStatusCode.OK, "video updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating video", e);
            }
        }

        [Route("api/video/remove/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                VideoService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Created, "video remove successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error removing video", e);
            }
        }
    }
}
