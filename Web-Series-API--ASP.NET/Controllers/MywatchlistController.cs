using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntityLayer;
using BusinessLogicLayer;

namespace Web_Series_API__ASP.NET.Controllers
{
    public class MywatchlistController : ApiController
    {
        [Route("api/mywatchlist/all")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, MywatchlistService.Get());
        }

        [Route("api/mywatchlist/create")]
        [HttpPost]
        public HttpResponseMessage Create(MywatchlistModel p)
        {
            MywatchlistService.Create(p);
            return Request.CreateResponse(HttpStatusCode.Created, "Data Insert");
        }

        //[Route("api/admin/CreateManager/")]
        //[HttpPost]
        //public void AddManager(ManagerModel n)
        //{
        //    ManagerService.Add(n);
        //}
        [Route("api/mywatchlist/EditManager/")]
        [HttpPost]
        public void UpdateMywatchlist(MywatchlistModel n)
        {
            MywatchlistService.Update(n);
        }
        [Route("api/mywatchlist/DeleteMywatchlist/")]
        [HttpPost]
        public void DeleteMywatchlist(MywatchlistModel n)
        {
            MywatchlistService.Delete(n);
        }

    }
}
