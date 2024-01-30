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
    public class documentsSelectController : ApiController
    {
        private documentsSelectRepository documentsSelectRepositoryC;
        public documentsSelectController()
        {
            this.documentsSelectRepositoryC = new documentsSelectRepository();
        }

        /// <summary>
        /// Select all documents.
        /// </summary>
        [SwaggerResponse(200, "The documents was returned", typeof(List<documents>))]
        [SwaggerResponse(400, "The documents data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {
            DataTable dt = this.documentsSelectRepositoryC.Select();
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select documents"), ReasonPhrase = "Unable to Select documents"};
            return (resp);
        }
    }
}