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
    public class addressbookFilterSelectController : ApiController
    {
        private addressbookFilterSelectRepository addressbookFilterSelectRepositoryC;
        public addressbookFilterSelectController()
        {
            this.addressbookFilterSelectRepositoryC = new addressbookFilterSelectRepository();
        }

        /// <summary>
        /// Select a specific or filter addressbook.
        /// </summary>
        [SwaggerResponse(200, "The addressbook was returned", typeof(List<addressbook>))]
        [SwaggerResponse(400, "The addressbook data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get(FilterModel FilterModelM)
        {
            DataTable dt = this.addressbookFilterSelectRepositoryC.Select(FilterModelM);
            if (dt != null)
                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {Content = new StringContent("Unable to Select addressbook"), ReasonPhrase = "Unable to Select addressbook"};
            return (resp);
        }
    }
}