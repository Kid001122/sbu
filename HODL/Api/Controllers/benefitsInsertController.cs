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
    public class benefitsInsertController : ApiController
    {
        private benefitsInsertRepository benefitsInsertRepositoryC;
        public benefitsInsertController()
        {
            this.benefitsInsertRepositoryC = new benefitsInsertRepository();
        }

        /// <summary>
        /// Inserts benefits.
        /// </summary>
        [SwaggerResponse(200, "The benefits was Inserted", typeof(List<benefits>))]
        [SwaggerResponse(400, "The benefits data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(benefits benefitsm)
        {
            benefits dt = this.benefitsInsertRepositoryC.Insert(benefitsm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Insert benefits"), ReasonPhrase = "Unable to Insert benefits"};
            return (resp);
        }
    }
}