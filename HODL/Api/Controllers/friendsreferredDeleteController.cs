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
    public class friendsreferredDeleteController : ApiController
    {
        private friendsreferredDeleteRepository friendsreferredDeleteRepositoryC;
        public friendsreferredDeleteController()
        {
            this.friendsreferredDeleteRepositoryC = new friendsreferredDeleteRepository();
        }

        /// <summary>
        /// Deletes a specific friendsreferred./// </summary>
        [SwaggerResponse(200, "The friendsreferred was deleted", typeof(friendsreferred))]
        [SwaggerResponse(400, "The friendsreferred data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(DeleteModel DeleteModelm)
        {
            DeleteModel dt = this.friendsreferredDeleteRepositoryC.Delete(DeleteModelm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Delete friendsreferred"), ReasonPhrase = "Unable to Delete friendsreferred"};
            return (resp);
        }
    }
}