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
using System.Web.Http.Cors;
using Swashbuckle.Swagger.Annotations;
using Api.Models;

namespace API.Controllers
{
    public class paymentlinkFilterSelectController : ApiController
    {
        private paymentlinkFilterSelectRepository paymentlinkFilterSelectRepositoryC;
        public paymentlinkFilterSelectController()
        {
            this.paymentlinkFilterSelectRepositoryC = new paymentlinkFilterSelectRepository();
        }

        /// <summary>
        /// Select a specific or filter paymentlink.
        /// </summary>
        [SwaggerResponse(200, "The paymentlink was returned", typeof(List<paymentlink>))]
        [SwaggerResponse(400, "The paymentlink data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get(FilterModel FilterModelM)
        {
            DataTable dt = this.paymentlinkFilterSelectRepositoryC.Select(FilterModelM);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select paymentlink"), ReasonPhrase = "Unable to Select paymentlink"};
            return (resp);
        }
    }
}