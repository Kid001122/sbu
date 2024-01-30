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
    public class walletDeleteController : ApiController
    {
        private walletDeleteRepository walletDeleteRepositoryC;
        public walletDeleteController()
        {
            this.walletDeleteRepositoryC = new walletDeleteRepository();
        }

        /// <summary>
        /// Deletes a specific wallet./// </summary>
        [SwaggerResponse(200, "The wallet was deleted", typeof(wallet))]
        [SwaggerResponse(400, "The wallet data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(DeleteModel DeleteModelm)
        {
            DeleteModel dt = this.walletDeleteRepositoryC.Delete(DeleteModelm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Delete wallet"), ReasonPhrase = "Unable to Delete wallet"};
            return (resp);
        }
    }
}