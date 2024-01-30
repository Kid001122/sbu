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
    public class friendsreferredSelectController : ApiController
    {
        private friendsreferredSelectRepository friendsreferredSelectRepositoryC;
        public friendsreferredSelectController()
        {
            this.friendsreferredSelectRepositoryC = new friendsreferredSelectRepository();
        }

        /// <summary>
        /// Select all friendsreferred.
        /// </summary>
        [SwaggerResponse(200, "The friendsreferred was returned", typeof(List<friendsreferred>))]
        [SwaggerResponse(400, "The friendsreferred data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {
            DataTable dt = this.friendsreferredSelectRepositoryC.Select();
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select friendsreferred"), ReasonPhrase = "Unable to Select friendsreferred"};
            return (resp);
        }
    }
}