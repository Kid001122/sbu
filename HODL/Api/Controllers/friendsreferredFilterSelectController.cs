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
    public class friendsreferredFilterSelectController : ApiController
    {
        private friendsreferredFilterSelectRepository friendsreferredFilterSelectRepositoryC;
        public friendsreferredFilterSelectController()
        {
            this.friendsreferredFilterSelectRepositoryC = new friendsreferredFilterSelectRepository();
        }

        /// <summary>
        /// Select a specific or filter friendsreferred.
        /// </summary>
        [SwaggerResponse(200, "The friendsreferred was returned", typeof(List<friendsreferred>))]
        [SwaggerResponse(400, "The friendsreferred data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get(FilterModel FilterModelM)
        {
            DataTable dt = this.friendsreferredFilterSelectRepositoryC.Select(FilterModelM);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select friendsreferred"), ReasonPhrase = "Unable to Select friendsreferred"};
            return (resp);
        }
    }
}