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
    public class documentsDeleteController : ApiController
    {
        private documentsDeleteRepository documentsDeleteRepositoryC;
        public documentsDeleteController()
        {
            this.documentsDeleteRepositoryC = new documentsDeleteRepository();
        }

        /// <summary>
        /// Deletes a specific documents./// </summary>
        [SwaggerResponse(200, "The documents was deleted", typeof(documents))]
        [SwaggerResponse(400, "The documents data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(DeleteModel DeleteModelm)
        {
            DeleteModel dt = this.documentsDeleteRepositoryC.Delete(DeleteModelm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Delete documents"), ReasonPhrase = "Unable to Delete documents"};
            return (resp);
        }
    }
}