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
    public class friendsreferredInsertController : ApiController
    {
        private friendsreferredInsertRepository friendsreferredInsertRepositoryC;
        public friendsreferredInsertController()
        {
            this.friendsreferredInsertRepositoryC = new friendsreferredInsertRepository();
        }

        /// <summary>
        /// Inserts friendsreferred.
        /// </summary>
        [SwaggerResponse(200, "The friendsreferred was Inserted", typeof(List<friendsreferred>))]
        [SwaggerResponse(400, "The friendsreferred data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(friendsreferred friendsreferredm)
        {
            friendsreferred dt = this.friendsreferredInsertRepositoryC.Insert(friendsreferredm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Insert friendsreferred"), ReasonPhrase = "Unable to Insert friendsreferred"};
            return (resp);
        }
    }
}