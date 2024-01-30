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
    public class useremploymentSelectController : ApiController
    {
        private useremploymentSelectRepository useremploymentSelectRepositoryC;
        public useremploymentSelectController()
        {
            this.useremploymentSelectRepositoryC = new useremploymentSelectRepository();
        }

        /// <summary>
        /// Select all useremployment.
        /// </summary>
        [SwaggerResponse(200, "The useremployment was returned", typeof(List<useremployment>))]
        [SwaggerResponse(400, "The useremployment data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {
            DataTable dt = this.useremploymentSelectRepositoryC.Select();
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select useremployment"), ReasonPhrase = "Unable to Select useremployment"};
            return (resp);
        }
    }
}