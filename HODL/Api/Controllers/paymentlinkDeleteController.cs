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
    public class paymentlinkDeleteController : ApiController
    {
        private paymentlinkDeleteRepository paymentlinkDeleteRepositoryC;
        public paymentlinkDeleteController()
        {
            this.paymentlinkDeleteRepositoryC = new paymentlinkDeleteRepository();
        }

        /// <summary>
        /// Deletes a specific paymentlink./// </summary>
        [SwaggerResponse(200, "The paymentlink was deleted", typeof(paymentlink))]
        [SwaggerResponse(400, "The paymentlink data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(DeleteModel DeleteModelm)
        {
            DeleteModel dt = this.paymentlinkDeleteRepositoryC.Delete(DeleteModelm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Delete paymentlink"), ReasonPhrase = "Unable to Delete paymentlink"};
            return (resp);
        }
    }
}