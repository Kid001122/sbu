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
    public class loyaltyFilterSelectController : ApiController
    {
        private loyaltyFilterSelectRepository loyaltyFilterSelectRepositoryC;
        public loyaltyFilterSelectController()
        {
            this.loyaltyFilterSelectRepositoryC = new loyaltyFilterSelectRepository();
        }

        /// <summary>
        /// Select a specific or filter loyalty.
        /// </summary>
        [SwaggerResponse(200, "The loyalty was returned", typeof(List<loyalty>))]
        [SwaggerResponse(400, "The loyalty data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get(FilterModel FilterModelM)
        {
            DataTable dt = this.loyaltyFilterSelectRepositoryC.Select(FilterModelM);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select loyalty"), ReasonPhrase = "Unable to Select loyalty"};
            return (resp);
        }
    }
}