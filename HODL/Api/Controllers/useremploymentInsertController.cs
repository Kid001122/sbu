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
    public class useremploymentInsertController : ApiController
    {
        private useremploymentInsertRepository useremploymentInsertRepositoryC;
        public useremploymentInsertController()
        {
            this.useremploymentInsertRepositoryC = new useremploymentInsertRepository();
        }

        /// <summary>
        /// Inserts useremployment.
        /// </summary>
        [SwaggerResponse(200, "The useremployment was Inserted", typeof(List<useremployment>))]
        [SwaggerResponse(400, "The useremployment data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(useremployment useremploymentm)
        {
            useremployment dt = this.useremploymentInsertRepositoryC.Insert(useremploymentm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Insert useremployment"), ReasonPhrase = "Unable to Insert useremployment"};
            return (resp);
        }
    }
}