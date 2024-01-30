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
    public class addressbookInsertController : ApiController
    {
        private addressbookInsertRepository addressbookInsertRepositoryC;
        public addressbookInsertController()
        {
            this.addressbookInsertRepositoryC = new addressbookInsertRepository();
        }

        /// <summary>
        /// Inserts addressbook.
        /// </summary>
        [SwaggerResponse(200, "The addressbook was Inserted", typeof(List<addressbook>))]
        [SwaggerResponse(400, "The addressbook data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post(addressbook addressbookm)
        {
            addressbook dt = this.addressbookInsertRepositoryC.Insert(addressbookm);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Insert addressbook"), ReasonPhrase = "Unable to Insert addressbook"};
            return (resp);
        }
    }
}