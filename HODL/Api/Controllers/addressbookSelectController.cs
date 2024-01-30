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
    public class addressbookSelectController : ApiController
    {
        private addressbookSelectRepository addressbookSelectRepositoryC;
        public addressbookSelectController()
        {
            this.addressbookSelectRepositoryC = new addressbookSelectRepository();
        }

        /// <summary>
        /// Select all addressbook.
        /// </summary>
        [SwaggerResponse(200, "The addressbook was returned", typeof(List<addressbook>))]
        [SwaggerResponse(400, "The addressbook data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {
            DataTable dt = this.addressbookSelectRepositoryC.Select();
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select addressbook"), ReasonPhrase = "Unable to Select addressbook"};
            return (resp);
        }
    }
}