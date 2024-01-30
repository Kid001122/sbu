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
    public class walletUpdateController : ApiController
    {
        private walletUpdateRepository walletUpdateRepositoryC;
        public walletUpdateController()
        {
            this.walletUpdateRepositoryC = new walletUpdateRepository();
        }

        /// <summary>
        /// Update specific wallet.
        /// </summary>
        [SwaggerResponse(200, "The wallet was updated", typeof(List<wallet>))]
        [SwaggerResponse(400, "The wallet data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(wallet walletm)
        {
            wallet dt = this.walletUpdateRepositoryC.Update(walletm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Update wallet"), ReasonPhrase = "Unable to  Update wallet"};
            return (resp);
        }
    }
}