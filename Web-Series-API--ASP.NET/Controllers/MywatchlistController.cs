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
    }
}
