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
using Swashbuckle.Swagger.Annotations;
using Api.Models;
using System.Web.Http.Cors;

namespace API.Controllers
{
    public class paymentlinkSelectController : ApiController
    {
        private paymentlinkSelectRepository paymentlinkSelectRepositoryC;
        public paymentlinkSelectController()
        {
            this.paymentlinkSelectRepositoryC = new paymentlinkSelectRepository();
        }

        /// <summary>
        /// Select all paymentlink.
        /// </summary>
        [SwaggerResponse(200, "The paymentlink was returned", typeof(List<paymentlink>))]
        [SwaggerResponse(400, "The paymentlink data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {
            DataTable dt = this.paymentlinkSelectRepositoryC.Select();
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select paymentlink"), ReasonPhrase = "Unable to Select paymentlink"};
            return (resp);
        }
    }
}