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
    public class loyaltyUpdateController : ApiController
    {
        private loyaltyUpdateRepository loyaltyUpdateRepositoryC;
        public loyaltyUpdateController()
        {
            this.loyaltyUpdateRepositoryC = new loyaltyUpdateRepository();
        }

        /// <summary>
        /// Update specific loyalty.
        /// </summary>
        [SwaggerResponse(200, "The loyalty was updated", typeof(List<loyalty>))]
        [SwaggerResponse(400, "The loyalty data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(loyalty loyaltym)
        {
            loyalty dt = this.loyaltyUpdateRepositoryC.Update(loyaltym);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Update loyalty"), ReasonPhrase = "Unable to  Update loyalty"};
            return (resp);
        }
    }
}