using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Api.Models;
using Api.Classes;
using Swashbuckle.Swagger.Annotations;
using API.Services;
using Api.Models;
using System.Web.Http.Cors;

namespace API.Controllers
{
    public class wallettransactionDeleteController : ApiController
    {
        private wallettransactionDeleteRepository wallettransactionDeleteRepositoryC;
        public wallettransactionDeleteController()
        {
            this.wallettransactionDeleteRepositoryC = new wallettransactionDeleteRepository();
        }

        /// <summary>
        /// Deletes a specific wallettransaction./// </summary>
        [SwaggerResponse(200, "The wallettransaction was deleted", typeof(wallettransaction))]
        [SwaggerResponse(400, "The wallettransaction data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(DeleteModel DeleteModelm)
        {
            DeleteModel dt = this.wallettransactionDeleteRepositoryC.Delete(DeleteModelm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Delete wallettransaction"), ReasonPhrase = "Unable to Delete wallettransaction"};
            return (resp);
        }
    }
}