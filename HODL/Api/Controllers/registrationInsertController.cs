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
    public class registrationInsertController : ApiController
    {
        private registrationInsertRepository registrationInsertRepositoryC;
        public registrationInsertController()
        {
            this.registrationInsertRepositoryC = new registrationInsertRepository();
        }

        /// <summary>
        /// Inserts registration.
        /// </summary>
        [SwaggerResponse(200, "The registration was Inserted", typeof(List<registration>))]
        [SwaggerResponse(400, "The registration data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(registration registrationm)
        {
            registration dt = this.registrationInsertRepositoryC.Insert(registrationm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            { Content = new StringContent("Unable to Insert registration"), ReasonPhrase = "Unable to Insert registration" };
            return (resp);
        }
    }
}