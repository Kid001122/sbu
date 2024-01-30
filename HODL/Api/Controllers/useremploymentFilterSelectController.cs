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
    public class useremploymentFilterSelectController : ApiController
    {
        private useremploymentFilterSelectRepository useremploymentFilterSelectRepositoryC;
        public useremploymentFilterSelectController()
        {
            this.useremploymentFilterSelectRepositoryC = new useremploymentFilterSelectRepository();
        }

        /// <summary>
        /// Select a specific or filter useremployment.
        /// </summary>
        [SwaggerResponse(200, "The useremployment was returned", typeof(List<useremployment>))]
        [SwaggerResponse(400, "The useremployment data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get(FilterModel FilterModelM)
        {
            DataTable dt = this.useremploymentFilterSelectRepositoryC.Select(FilterModelM);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select useremployment"), ReasonPhrase = "Unable to Select useremployment"};
            return (resp);
        }
    }
}