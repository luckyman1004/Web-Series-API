using BusinessEntityLayer;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Web_Series_API__ASP.NET.Controllers
{
    public class SubscriptionController : ApiController
    {
        [Route("api/subscriptions")]
        [HttpGet]
        public HttpResponseMessage GetSubList()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SubscriptionService.GetSubscriptions());
        }

        [Route("api/Subscription/all")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SubscriptionService.Get());
        }

        [Route("api/Subscription/create")]
        [HttpPost]
        public HttpResponseMessage Create(SubscriptionModel p)
        {
            SubscriptionService.Create(p);
            return Request.CreateResponse(HttpStatusCode.Created, "Data Insert");
        }

        [Route("api/Subscription/updateSubscription")]
        [HttpPost]
        public void UpdateSubscription(SubscriptionModel n)
        {
            SubscriptionService.Update(n);
        }
        [Route("api/Subscription/DeleteSubscription")]
        [HttpPost]
        public void DeleteSubscription(SubscriptionModel n)
        {
            SubscriptionService.Delete(n);
        }
    }
}