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
using System.Web.Http.Cors;
using Swashbuckle.Swagger.Annotations;
using Api.Models;

namespace API.Controllers
{
    public class registrationFilterSelectController : ApiController
    {
        private registrationFilterSelectRepository registrationFilterSelectRepositoryC;
        public registrationFilterSelectController()
        {
            this.registrationFilterSelectRepositoryC = new registrationFilterSelectRepository();
        }

        /// <summary>
        /// Select a specific or filter registration.
        /// </summary>
        [SwaggerResponse(200, "The registration was returned", typeof(List<registration>))]
        [SwaggerResponse(400, "The registration data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get(FilterModel FilterModelM)
        {
            DataTable dt = this.registrationFilterSelectRepositoryC.Select(FilterModelM);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select registration"), ReasonPhrase = "Unable to Select registration"};
            return (resp);
        }
    }
}