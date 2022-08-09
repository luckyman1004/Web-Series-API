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
            return Request.CreateResponse(HttpStatusCode.OK, PackageService.GetPackageNames()); 
        }

        [Route("api/package/all")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, PackageService.Get());
        }

        [Route("api/package/create")]
        [HttpPost]
        public HttpResponseMessage Create(PackageModel p)
        {
            PackageService.Create(p);    
            return Request.CreateResponse(HttpStatusCode.Created, "Data Insert");
        }

        [Route("api/package/updatepackage")]
        [HttpPost]
        public void UpdatePackage(PackageModel n)
        {
            PackageService.Update(n);
        }
        [Route("api/package/Deletepackage")]
        [HttpPost]
        public void DeletePackage(PackageModel n)
        {
            PackageService.Delete(n);
        }
    }
}
