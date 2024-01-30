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
    public class wallettransactionInsertController : ApiController
    {
        private wallettransactionInsertRepository wallettransactionInsertRepositoryC;
        public wallettransactionInsertController()
        {
            this.wallettransactionInsertRepositoryC = new wallettransactionInsertRepository();
        }

        /// <summary>
        /// Inserts wallettransaction.
        /// </summary>
        [SwaggerResponse(200, "The wallettransaction was Inserted", typeof(List<wallettransaction>))]
        [SwaggerResponse(400, "The wallettransaction data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(wallettransaction wallettransactionm)
        {
            wallettransaction dt = this.wallettransactionInsertRepositoryC.Insert(wallettransactionm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Insert wallettransaction"), ReasonPhrase = "Unable to Insert wallettransaction"};
            return (resp);
        }
    }
}