using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Swashbuckle.Swagger.Annotations;
using Api.Models;
using API.Services;
using Api.Classes;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace API.Controllers
{
    public class RegistrationUpdateController : ApiController
    {
        private registrationUpdateRepository registrationUpdateRepositoryC;

        public RegistrationUpdateController()
        {
            this.registrationUpdateRepositoryC = new registrationUpdateRepository();
        }

        [SwaggerResponse(200, "The registration was updated", typeof(List<registration>))]
        [SwaggerResponse(400, "The registration data is invalid")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post(registration registrationData)
        {
            string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBY2Nlc3NLZXkiOiJkZWNhMWJlZi1hYzNlLTRjMzctODA2Ni0wNTAwY2E4ZmIwYzciLCJDbGllbnRJZCI6IjExNSIsIlVzZXJJZCI6ImZlNDA3MTgxLWFiYjYtNDk5Ni1hMjBiLTRjNzZjM2Y3ODNkOCIsIm5iZiI6MTcwNjUzMzY2NywiZXhwIjo0ODYyMjA3MjY3LCJpYXQiOjE3MDY1MzM2NjcsImF1ZCI6IkJlZXNXYXgifQ.PRGTSLY06VO76pTiJ75HHMrhAyu29Su0z1vpS0l-8Z4"; // Replace with actual method to retrieve token

            registration dt = this.registrationUpdateRepositoryC.Update(registrationData);
            if (dt != null)
            {
                await SendToHoneycombAPI(dt, bearerToken);

                return this.Request.CreateResponse(HttpStatusCode.OK, dt);
            }

            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Unable to Update registration"),
                ReasonPhrase = "Unable to Update registration"
            };
            return resp;
        }
        private async Task SendToHoneycombAPI(registration registrationData, string bearerToken)
        {
            using (var client = new HttpClient())
            {
                string honeycombEndpoint = "https://publicapi.honeycombonline.co.za/natural-person-idv-photo";

                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(registrationData.RegistrationID ?? string.Empty), "MatterPerson.UniqueId");
                formData.Add(new StringContent(registrationData.Name ?? string.Empty), "MatterPerson.FirstName");
                formData.Add(new StringContent(registrationData.LastName ?? string.Empty), "MatterPerson.Surname");
                formData.Add(new StringContent(registrationData.IdentityNumber ?? string.Empty), "MatterPerson.IdentityNumber");
                formData.Add(new StringContent(registrationData.IdCardFront ?? string.Empty), "IdCardFront");
                formData.Add(new StringContent(registrationData.IdCardBack ?? string.Empty), "IdCardBack");
                formData.Add(new StringContent(registrationData.PassportFront ?? string.Empty), "PassportFront");
                formData.Add(new StringContent(registrationData.DriversFront ?? string.Empty), "DriversFront");
                formData.Add(new StringContent(registrationData.DriversBack ?? string.Empty), "DriversBack");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                HttpResponseMessage response = await client.PostAsync(honeycombEndpoint, formData);

                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    registrationData.HoneyCombResult = responseBody;
                    Console.WriteLine($"Successfully sent data to Honeycomb API: {responseBody}");
                    
                }
                else
                {

                    throw new HttpRequestException($"Error sending data to Honeycomb API: {response.StatusCode} {responseBody}");
                }
            }
        }
    }
}
