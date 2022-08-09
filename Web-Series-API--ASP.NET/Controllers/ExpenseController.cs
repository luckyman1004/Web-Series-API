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
    public class ExpenseController : ApiController
    {
        [Route("api/expenses")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, ExpansService.Get());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error no expenses found", e);
            }
        }

        [Route("api/expense/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, ExpansService.Get(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error expense not found", e);
            }
        }

        [Route("api/expense/create")]
        [HttpPost]
        public HttpResponseMessage Post(ExpansModel expense)
        {
            try
            {
                ExpansService.Create(expense);
                return Request.CreateResponse(HttpStatusCode.Created, "expense inserted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding expense", e);
            }
        }

        [Route("api/expense/edit")]
        [HttpPut]
        public HttpResponseMessage Put(ExpansModel expense)
        {
            try
            {
                ExpansService.Update(expense);
                return Request.CreateResponse(HttpStatusCode.OK, "Expense updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating expense", e);
            }
        }

        [Route("api/expense/remove/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ExpansService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Created, "Expense remove successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error removing expense", e);
            }
        }
    }
}
