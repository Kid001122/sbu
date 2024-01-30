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
    public class wallettransactionFilterSelectController : ApiController
    {
        private wallettransactionFilterSelectRepository wallettransactionFilterSelectRepositoryC;
        public wallettransactionFilterSelectController()
        {
            this.wallettransactionFilterSelectRepositoryC = new wallettransactionFilterSelectRepository();
        }

        /// <summary>
        /// Select a specific or filter wallettransaction.
        /// </summary>
        [SwaggerResponse(200, "The wallettransaction was returned", typeof(List<wallettransaction>))]
        [SwaggerResponse(400, "The wallettransaction data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get(FilterModel FilterModelM)
        {
            DataTable dt = this.wallettransactionFilterSelectRepositoryC.Select(FilterModelM);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select wallettransaction"), ReasonPhrase = "Unable to Select wallettransaction"};
            return (resp);
        }
    }
}