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
    public class walletFilterSelectController : ApiController
    {
        private walletFilterSelectRepository walletFilterSelectRepositoryC;
        public walletFilterSelectController()
        {
            this.walletFilterSelectRepositoryC = new walletFilterSelectRepository();
        }

        /// <summary>
        /// Select a specific or filter wallet.
        /// </summary>
        [SwaggerResponse(200, "The wallet was returned", typeof(List<wallet>))]
        [SwaggerResponse(400, "The wallet data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get(FilterModel FilterModelM)
        {
            DataTable dt = this.walletFilterSelectRepositoryC.Select(FilterModelM);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select wallet"), ReasonPhrase = "Unable to Select wallet"};
            return (resp);
        }
    }
}