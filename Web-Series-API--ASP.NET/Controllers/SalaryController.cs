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
    public class SalaryController : ApiController
    {
        [Route("api/salaries")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, SalaryService.Get());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error no salaries found", e);
            }
        }

        [Route("api/salary/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, SalaryService.Get(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error salary not found", e);
            }
        }

        [Route("api/salary/create")]
        [HttpPost]
        public HttpResponseMessage Post(SalaryModel salary)
        {
            try
            {
                SalaryService.Create(salary);
                return Request.CreateResponse(HttpStatusCode.Created, "salary inserted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding salary", e);
            }
        }

        [Route("api/salary/edit")]
        [HttpPut]
        public HttpResponseMessage Put(SalaryModel salary)
        {
            try
            {
                SalaryService.Update(salary);
                return Request.CreateResponse(HttpStatusCode.OK, "Salary updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating salary", e);
            }
        }

        [Route("api/salary/remove/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                SalaryService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Created, "Salary remove successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error removing salary", e);
            }
        }
    }
}
