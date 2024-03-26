using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using HodlSolution.Model;
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Http.Headers;

namespace HodlSolution.Controllers
{

    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly string connectionString = "Server=129.232.251.122;Database=hodlotc_db;Uid=hodladmin;Pwd=L3mWjfUDK2md8yMUb698";
        [Route("api/RegistrationInsert")]
        [HttpPost]
        public IActionResult Register([FromBody] Registration registration)
        {
            if (registration == null)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "Insert into  registration(RegistrationID , CompanyName,TrustRegNum, TrustName , CompanyVat , Name , LastName , MiddleName , Email , Password , City , Country , PostalCode , Suburb , StreetNumber , StreetName , PhoneNumber , EmailVerified , IdVerified , TwoFactorAuthLink , TwoFactorAuthStatus ) Values(@RegistrationID , @CompanyName ,@TrustRegNum,@TrustName, @CompanyVat , @Name , @LastName , @MiddleName , @Email , @Password , @City , @Country , @PostalCode , @Suburb , @StreetNumber , @StreetName , @PhoneNumber , @EmailVerified , @IdVerified , @TwoFactorAuthLink , @TwoFactorAuthStatus );";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(@"RegistrationID", registration.RegistrationID);
                        cmd.Parameters.AddWithValue(@"CompanyName", registration.CompanyName);
                        cmd.Parameters.AddWithValue(@"CompanyVat", registration.CompanyVat);
                        cmd.Parameters.AddWithValue("@TrustRegNum", registration.TrustRegNum);
                        cmd.Parameters.AddWithValue("@TrustName", registration.TrustName);
                        cmd.Parameters.AddWithValue(@"Name", registration.Name);
                        cmd.Parameters.AddWithValue(@"LastName", registration.LastName);
                        cmd.Parameters.AddWithValue(@"MiddleName", registration.MiddleName);
                        cmd.Parameters.AddWithValue(@"Email", registration.Email);
                        cmd.Parameters.AddWithValue(@"Password", registration.Password);
                        cmd.Parameters.AddWithValue(@"City", registration.City);
                        cmd.Parameters.AddWithValue(@"Country", registration.Country);
                        cmd.Parameters.AddWithValue(@"PostalCode", registration.PostalCode);
                        cmd.Parameters.AddWithValue(@"Suburb", registration.Suburb);
                        cmd.Parameters.AddWithValue(@"StreetNumber", registration.StreetNumber);
                        cmd.Parameters.AddWithValue(@"StreetName", registration.StreetName);
                        cmd.Parameters.AddWithValue(@"PhoneNumber", registration.PhoneNumber);
                        cmd.Parameters.AddWithValue(@"EmailVerified", registration.EmailVerified);
                        cmd.Parameters.AddWithValue(@"IdVerified", registration.IdVerified);
                        cmd.Parameters.AddWithValue(@"TwoFactorAuthLink", registration.TwoFactorAuthLink);
                        cmd.Parameters.AddWithValue(@"TwoFactorAuthStatus", registration.TwoFactorAuthStatus);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Ok("Registration successful");
                        }
                        else
                        {
                            return BadRequest("Registration failed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("api/RegistrationSelect")]
        [HttpGet]
        public IActionResult GetRegistrations()
        {

            try
            {
                List<Registration> registrations = new List<Registration>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM registration";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Registration registration = new Registration
                                {
                                    RegistrationID = reader.IsDBNull(reader.GetOrdinal("RegistrationID")) ? 0 : reader.GetInt32(reader.GetOrdinal("RegistrationID")),
                                    CompanyName = reader.IsDBNull(reader.GetOrdinal("CompanyName")) ? string.Empty : reader.GetString(reader.GetOrdinal("CompanyName")),
                                    CompanyVat = reader.IsDBNull(reader.GetOrdinal("CompanyVat")) ? string.Empty : reader.GetString(reader.GetOrdinal("CompanyVat")),
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name")),
                                    LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? string.Empty : reader.GetString(reader.GetOrdinal("LastName")),
                                    MiddleName = reader.IsDBNull(reader.GetOrdinal("MiddleName")) ? string.Empty : reader.GetString(reader.GetOrdinal("MiddleName")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? string.Empty : reader.GetString(reader.GetOrdinal("Email")),
                                    Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? string.Empty : reader.GetString(reader.GetOrdinal("Password")),
                                    City = reader.IsDBNull(reader.GetOrdinal("City")) ? string.Empty : reader.GetString(reader.GetOrdinal("City")),
                                    Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? string.Empty : reader.GetString(reader.GetOrdinal("Country")),
                                    PostalCode = reader.IsDBNull(reader.GetOrdinal("PostalCode")) ? string.Empty : reader.GetString(reader.GetOrdinal("PostalCode")),
                                    Suburb = reader.IsDBNull(reader.GetOrdinal("Suburb")) ? string.Empty : reader.GetString(reader.GetOrdinal("Suburb")),
                                    StreetNumber = reader.IsDBNull(reader.GetOrdinal("StreetNumber")) ? string.Empty : reader.GetString(reader.GetOrdinal("StreetNumber")),
                                    StreetName = reader.IsDBNull(reader.GetOrdinal("StreetName")) ? string.Empty : reader.GetString(reader.GetOrdinal("StreetName")),
                                    PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? string.Empty : reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    EmailVerified = reader.IsDBNull(reader.GetOrdinal("EmailVerified")) ? string.Empty : reader.GetString(reader.GetOrdinal("EmailVerified")),
                                    IdVerified = reader.IsDBNull(reader.GetOrdinal("IdVerified")) ? string.Empty : reader.GetString(reader.GetOrdinal("IdVerified")),
                                    TwoFactorAuthLink = reader.IsDBNull(reader.GetOrdinal("TwoFactorAuthLink")) ? string.Empty : reader.GetString(reader.GetOrdinal("TwoFactorAuthLink")),
                                    TwoFactorAuthStatus = reader.IsDBNull(reader.GetOrdinal("TwoFactorAuthStatus")) ? string.Empty : reader.GetString(reader.GetOrdinal("TwoFactorAuthStatus")),
                                  //  IdBookFront = reader.IsDBNull(reader.GetOrdinal("IdBookFront")) ? string.Empty : reader.GetString(reader.GetOrdinal("IdBookFront")),
                                    DriversFront = reader.IsDBNull(reader.GetOrdinal("driversFront")) ? string.Empty : reader.GetString(reader.GetOrdinal("driversFront")),
                                    DriversBack = reader.IsDBNull(reader.GetOrdinal("driversBack")) ? string.Empty : reader.GetString(reader.GetOrdinal("driversBack")),
                                    IdCardFront = reader.IsDBNull(reader.GetOrdinal("idCardFront")) ? string.Empty : reader.GetString(reader.GetOrdinal("idCardFront")),
                                    IdCardBack = reader.IsDBNull(reader.GetOrdinal("idCardBack")) ? string.Empty : reader.GetString(reader.GetOrdinal("idCardBack")),
                                    PassportFront = reader.IsDBNull(reader.GetOrdinal("passportFront")) ? string.Empty : reader.GetString(reader.GetOrdinal("passportFront")),
                                   // HoneyCombResult = reader.IsDBNull(reader.GetOrdinal("honeyCombResult")) ? string.Empty : reader.GetString(reader.GetOrdinal("honeyCombResult"))
                                };

                                registrations.Add(registration);
                            }
                        }
                    }
                }

                return Ok(registrations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("api/RegistrationUpdate")]
        [HttpPut]
        public async Task<IActionResult> UpdateRegistration(Registration registration)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE registration SET IdentityNumber=@IdentityNumber,Name = @Name, LastName = @LastName, MiddleName = @MiddleName, City = @City, Country = @Country, PostalCode = @PostalCode, Suburb = @Suburb, StreetNumber = @StreetNumber, StreetName = @StreetName, PhoneNumber = @PhoneNumber, EmailVerified = @EmailVerified, IdVerified = @IdVerified, TwoFactorAuthLink = @TwoFactorAuthLink, TwoFactorAuthStatus = @TwoFactorAuthStatus WHERE Email = @Email";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", registration.Name);
                        cmd.Parameters.AddWithValue("@IdentityNumber", registration.IdentityNumber);
                        cmd.Parameters.AddWithValue("@LastName", registration.LastName);
                        cmd.Parameters.AddWithValue("@MiddleName", registration.MiddleName);
                        cmd.Parameters.AddWithValue("@City", registration.City);
                        cmd.Parameters.AddWithValue("@Country", registration.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", registration.PostalCode);
                        cmd.Parameters.AddWithValue("@Suburb", registration.Suburb);
                        cmd.Parameters.AddWithValue("@StreetNumber", registration.StreetNumber);
                        cmd.Parameters.AddWithValue("@StreetName", registration.StreetName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", registration.PhoneNumber);
                        cmd.Parameters.AddWithValue("@EmailVerified", registration.EmailVerified);
                        cmd.Parameters.AddWithValue("@IdVerified", registration.IdVerified);
                        cmd.Parameters.AddWithValue("@TwoFactorAuthLink", registration.TwoFactorAuthLink);
                        cmd.Parameters.AddWithValue("@TwoFactorAuthStatus", registration.TwoFactorAuthStatus);
                        cmd.Parameters.AddWithValue("@Email", registration.Email);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBY2Nlc3NLZXkiOiJkZWNhMWJlZi1hYzNlLTRjMzctODA2Ni0wNTAwY2E4ZmIwYzciLCJDbGllbnRJZCI6IjExNSIsIlVzZXJJZCI6ImZlNDA3MTgxLWFiYjYtNDk5Ni1hMjBiLTRjNzZjM2Y3ODNkOCIsIm5iZiI6MTcwNjUzMzY2NywiZXhwIjo0ODYyMjA3MjY3LCJpYXQiOjE3MDY1MzM2NjcsImF1ZCI6IkJlZXNXYXgifQ.PRGTSLY06VO76pTiJ75HHMrhAyu29Su0z1vpS0l-8Z4";
                            string honeyCombResult = await SendToHoneycombAPI(registration, bearerToken);
                            registration.HoneyCombResult = honeyCombResult;
                            return Ok(registration);
                        }
                        else
                        {
                            return NotFound("Registration not found");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [Route("api/RegistrationDelete")]
        [HttpDelete]
        public IActionResult DeleteRegistration(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM registration WHERE Email = @Email";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Ok("Registration deleted successfully");
                        }
                        else
                        {
                            return NotFound("Registration not found");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        private async Task<string> SendToHoneycombAPI(Registration registrationData, string bearerToken)
        {
            using (var client = new HttpClient())
            {
                string honeycombEndpoint = "https://publicapi.honeycombonline.co.za/natural-person-idv-photo";

                var formData = new MultipartFormDataContent();
               // formData.Add(new StringContent(registrationData.RegistrationID ?? string.Empty), "MatterPerson.UniqueId");
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
                    Console.WriteLine($"Successfully sent data to Honeycomb API: {responseBody}");
                    return responseBody;
                }
                else
                {
                    throw new HttpRequestException($"Error sending data to Honeycomb API: {response.StatusCode} {responseBody}");
                }
            }

        }
    }
}
