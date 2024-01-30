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
    public class benefitsDeleteController : ApiController
    {
        private benefitsDeleteRepository benefitsDeleteRepositoryC;
        public benefitsDeleteController()
        {
            this.benefitsDeleteRepositoryC = new benefitsDeleteRepository();
        }

        /// <summary>
        /// Deletes a specific benefits./// </summary>
        [SwaggerResponse(200, "The benefits was deleted", typeof(benefits))]
        [SwaggerResponse(400, "The benefits data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(DeleteModel DeleteModelm)
        {
            DeleteModel dt = this.benefitsDeleteRepositoryC.Delete(DeleteModelm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Delete benefits"), ReasonPhrase = "Unable to Delete benefits"};
            return (resp);
        }
    }
}