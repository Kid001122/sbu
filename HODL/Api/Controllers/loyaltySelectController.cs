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
    public class loyaltySelectController : ApiController
    {
        private loyaltySelectRepository loyaltySelectRepositoryC;
        public loyaltySelectController()
        {
            this.loyaltySelectRepositoryC = new loyaltySelectRepository();
        }

        /// <summary>
        /// Select all loyalty.
        /// </summary>
        [SwaggerResponse(200, "The loyalty was returned", typeof(List<loyalty>))]
        [SwaggerResponse(400, "The loyalty data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {
            DataTable dt = this.loyaltySelectRepositoryC.Select();
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select loyalty"), ReasonPhrase = "Unable to Select loyalty"};
            return (resp);
        }
    }
}