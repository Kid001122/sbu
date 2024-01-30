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
    public class useremploymentDeleteController : ApiController
    {
        private useremploymentDeleteRepository useremploymentDeleteRepositoryC;
        public useremploymentDeleteController()
        {
            this.useremploymentDeleteRepositoryC = new useremploymentDeleteRepository();
        }

        /// <summary>
        /// Deletes a specific useremployment./// </summary>
        [SwaggerResponse(200, "The useremployment was deleted", typeof(useremployment))]
        [SwaggerResponse(400, "The useremployment data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(DeleteModel DeleteModelm)
        {
            DeleteModel dt = this.useremploymentDeleteRepositoryC.Delete(DeleteModelm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Delete useremployment"), ReasonPhrase = "Unable to Delete useremployment"};
            return (resp);
        }
    }
}