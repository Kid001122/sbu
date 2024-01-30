using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Services;
using Api.Classes;
using System.Data;
using Api.Models;
using Api.Classes;
using System.Web.Http.Cors;
using Swashbuckle.Swagger.Annotations;

namespace API.Controllers
{
    public class paymentlinkUpdateController : ApiController
    {
        private paymentlinkUpdateRepository paymentlinkUpdateRepositoryC;
        public paymentlinkUpdateController()
        {
            this.paymentlinkUpdateRepositoryC = new paymentlinkUpdateRepository();
        }

        /// <summary>
        /// Update specific paymentlink.
        /// </summary>
        [SwaggerResponse(200, "The paymentlink was updated", typeof(List<paymentlink>))]
        [SwaggerResponse(400, "The paymentlink data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(paymentlink paymentlinkm)
        {
            paymentlink dt = this.paymentlinkUpdateRepositoryC.Update(paymentlinkm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Update paymentlink"), ReasonPhrase = "Unable to  Update paymentlink"};
            return (resp);
        }
    }
}