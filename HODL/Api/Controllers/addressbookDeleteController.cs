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
    public class addressbookDeleteController : ApiController
    {
        private addressbookDeleteRepository addressbookDeleteRepositoryC;
        public addressbookDeleteController()
        {
            this.addressbookDeleteRepositoryC = new addressbookDeleteRepository();
        }

        /// <summary>
        /// Deletes a specific addressbook./// </summary>
        [SwaggerResponse(200, "The addressbook was deleted", typeof(addressbook))]
        [SwaggerResponse(400, "The addressbook data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Delete(DeleteModel DeleteModelm)
        {
            DeleteModel dt = this.addressbookDeleteRepositoryC.Delete(DeleteModelm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Delete addressbook"), ReasonPhrase = "Unable to Delete addressbook"};
            return (resp);
        }
    }
}