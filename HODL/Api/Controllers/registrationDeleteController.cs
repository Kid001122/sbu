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
    public class registrationDeleteController : ApiController
    {
        private registrationDeleteRepository registrationDeleteRepositoryC;
        public registrationDeleteController()
        {
            this.registrationDeleteRepositoryC = new registrationDeleteRepository();
        }

        /// <summary>
        /// Deletes a specific registration./// </summary>
        [SwaggerResponse(200, "The registration was deleted", typeof(registration))]
        [SwaggerResponse(400, "The registration data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(DeleteModel DeleteModelm)
        {
            DeleteModel dt = this.registrationDeleteRepositoryC.Delete(DeleteModelm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Delete registration"), ReasonPhrase = "Unable to Delete registration"};
            return (resp);
        }
    }
}