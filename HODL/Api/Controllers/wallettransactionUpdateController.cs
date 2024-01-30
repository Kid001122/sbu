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
    public class wallettransactionUpdateController : ApiController
    {
        private wallettransactionUpdateRepository wallettransactionUpdateRepositoryC;
        public wallettransactionUpdateController()
        {
            this.wallettransactionUpdateRepositoryC = new wallettransactionUpdateRepository();
        }

        /// <summary>
        /// Update specific wallettransaction.
        /// </summary>
        [SwaggerResponse(200, "The wallettransaction was updated", typeof(List<wallettransaction>))]
        [SwaggerResponse(400, "The wallettransaction data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(wallettransaction wallettransactionm)
        {
            wallettransaction dt = this.wallettransactionUpdateRepositoryC.Update(wallettransactionm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Update wallettransaction"), ReasonPhrase = "Unable to  Update wallettransaction"};
            return (resp);
        }
    }
}