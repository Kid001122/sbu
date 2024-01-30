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
    public class walletInsertController : ApiController
    {
        private walletInsertRepository walletInsertRepositoryC;
        public walletInsertController()
        {
            this.walletInsertRepositoryC = new walletInsertRepository();
        }

        /// <summary>
        /// Inserts wallet.
        /// </summary>
        [SwaggerResponse(200, "The wallet was Inserted", typeof(List<wallet>))]
        [SwaggerResponse(400, "The wallet data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(wallet walletm)
        {
            wallet dt = this.walletInsertRepositoryC.Insert(walletm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Insert wallet"), ReasonPhrase = "Unable to Insert wallet"};
            return (resp);
        }
    }
}