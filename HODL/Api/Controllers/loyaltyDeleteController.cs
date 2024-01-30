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
    public class loyaltyDeleteController : ApiController
    {
        private loyaltyDeleteRepository loyaltyDeleteRepositoryC;
        public loyaltyDeleteController()
        {
            this.loyaltyDeleteRepositoryC = new loyaltyDeleteRepository();
        }

        /// <summary>
        /// Deletes a specific loyalty./// </summary>
        [SwaggerResponse(200, "The loyalty was deleted", typeof(loyalty))]
        [SwaggerResponse(400, "The loyalty data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(DeleteModel DeleteModelm)
        {
            DeleteModel dt = this.loyaltyDeleteRepositoryC.Delete(DeleteModelm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Delete loyalty"), ReasonPhrase = "Unable to Delete loyalty"};
            return (resp);
        }
    }
}