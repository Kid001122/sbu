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
    public class documentsUpdateController : ApiController
    {
        private documentsUpdateRepository documentsUpdateRepositoryC;
        public documentsUpdateController()
        {
            this.documentsUpdateRepositoryC = new documentsUpdateRepository();
        }

        /// <summary>
        /// Update specific documents.
        /// </summary>
        [SwaggerResponse(200, "The documents was updated", typeof(List<documents>))]
        [SwaggerResponse(400, "The documents data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(documents documentsm)
        {
            documents dt = this.documentsUpdateRepositoryC.Update(documentsm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Update documents"), ReasonPhrase = "Unable to  Update documents"};
            return (resp);
        }
    }
}