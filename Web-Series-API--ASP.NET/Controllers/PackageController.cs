using BusinessEntityLayer;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_Series_API__ASP.NET.Controllers
{
    public class PackageController : ApiController
    {
        [Route("api/package/names")]
        [HttpGet]
        public HttpResponseMessage GetNames()
        {
            //return PackageService.GetPackageNames();
            return Request.CreateResponse(HttpStatusCode.OK, PackageService.GetPackageNames()); 
        }


        [Route("api/package/all")]
        [HttpGet]
        public List<PackageModel> GetAll()
        {
            return PackageService.Get();
        }
    }
}
