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
    public class walletSelectController : ApiController
    {
        private walletSelectRepository walletSelectRepositoryC;
        public walletSelectController()
        {
            this.walletSelectRepositoryC = new walletSelectRepository();
        }

        /// <summary>
        /// Select all wallet.
        /// </summary>
        [SwaggerResponse(200, "The wallet was returned", typeof(List<wallet>))]
        [SwaggerResponse(400, "The wallet data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {
            DataTable dt = this.walletSelectRepositoryC.Select();
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select wallet"), ReasonPhrase = "Unable to Select wallet"};
            return (resp);
        }
    }
}