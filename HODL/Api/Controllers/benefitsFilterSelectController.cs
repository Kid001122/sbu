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
    public class benefitsFilterSelectController : ApiController
    {
        private benefitsFilterSelectRepository benefitsFilterSelectRepositoryC;
        public benefitsFilterSelectController()
        {
            this.benefitsFilterSelectRepositoryC = new benefitsFilterSelectRepository();
        }

        /// <summary>
        /// Select a specific or filter benefits.
        /// </summary>
        [SwaggerResponse(200, "The benefits was returned", typeof(List<benefits>))]
        [SwaggerResponse(400, "The benefits data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get(FilterModel FilterModelM)
        {
            DataTable dt = this.benefitsFilterSelectRepositoryC.Select(FilterModelM);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select benefits"), ReasonPhrase = "Unable to Select benefits"};
            return (resp);
        }
    }
}