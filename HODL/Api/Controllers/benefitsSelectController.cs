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
    public class benefitsSelectController : ApiController
    {
        private benefitsSelectRepository benefitsSelectRepositoryC;
        public benefitsSelectController()
        {
            this.benefitsSelectRepositoryC = new benefitsSelectRepository();
        }

        /// <summary>
        /// Select all benefits.
        /// </summary>
        [SwaggerResponse(200, "The benefits was returned", typeof(List<benefits>))]
        [SwaggerResponse(400, "The benefits data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {
            DataTable dt = this.benefitsSelectRepositoryC.Select();
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select benefits"), ReasonPhrase = "Unable to Select benefits"};
            return (resp);
        }
    }
}