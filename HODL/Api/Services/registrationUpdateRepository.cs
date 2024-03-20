using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace API.Services
{
    public class registrationUpdateRepository
    {
        public registration Update(registration registrationm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "UPDATE registration SET " +
     "Role = @Role, " +
     "CompanyRegNum = @CompanyRegNum, " +
     "CompanyName = @CompanyName, " +
     "CompanyVat = @CompanyVat, " +
     "TrustRegNum = @TrustRegNum, " +
     "TrustName = @TrustName, " +
     "IdentityNumber = @IdentityNumber, " +
     "Passport = @Passport, " +
     "Name = @Name, " +
     "LastName = @LastName, " +
     "MiddleName = @MiddleName, " +
     "Email = @Email, " +
     "Password = @Password, " +
     "City = @City, " +
     "Province = @Province, " +
     "Country = @Country, " +
     "PostalCode = @PostalCode, " +
     "Suburb = @Suburb, " +
     "StreetNumber = @StreetNumber, " +
     "StreetName = @StreetName, " +
     "PhoneNumber = @PhoneNumber, " +
     "EmailVerified = @EmailVerified, " +
     "IdVerified = @IdVerified, " +
     "TwoFactorAuthLink = @TwoFactorAuthLink, " +
     "TwoFactorAuthStatus = @TwoFactorAuthStatus, " +
     "DriversFront = @DriversFront, " +
     "DriversBack = @DriversBack, " +
     "IdCardFront = @IdCardFront, " +
     "IdCardBack = @IdCardBack, " +
     "PassportFront = @PassportFront " +
     "WHERE Email = @Email";

                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@Role", registrationm.Role);
                cmd.Parameters.AddWithValue("@CompanyRegNum", registrationm.CompanyRegNum);
                cmd.Parameters.AddWithValue("@CompanyName", registrationm.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyVat", registrationm.CompanyVat);
                cmd.Parameters.AddWithValue("@TrustRegNum", registrationm.TrustRegNum);
                cmd.Parameters.AddWithValue("@TrustName", registrationm.TrustName);
                cmd.Parameters.AddWithValue("@IdentityNumber", registrationm.IdentityNumber);
                cmd.Parameters.AddWithValue("@Passport", registrationm.Passport);
                cmd.Parameters.AddWithValue("@Name", registrationm.Name);
                cmd.Parameters.AddWithValue("@LastName", registrationm.LastName);
                cmd.Parameters.AddWithValue("@MiddleName", registrationm.MiddleName);
                cmd.Parameters.AddWithValue("@Email", registrationm.Email);
                cmd.Parameters.AddWithValue("@Password", registrationm.Password);
                cmd.Parameters.AddWithValue("@City", registrationm.City);
                cmd.Parameters.AddWithValue("@Province", registrationm.Province);
                cmd.Parameters.AddWithValue("@Country", registrationm.Country);
                cmd.Parameters.AddWithValue("@PostalCode", registrationm.PostalCode);
                cmd.Parameters.AddWithValue("@Suburb", registrationm.Suburb);
                cmd.Parameters.AddWithValue("@StreetNumber", registrationm.StreetNumber);
                cmd.Parameters.AddWithValue("@StreetName", registrationm.StreetName);
                cmd.Parameters.AddWithValue("@PhoneNumber", registrationm.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmailVerified", registrationm.EmailVerified);
                cmd.Parameters.AddWithValue("@IdVerified", registrationm.IdVerified);
                cmd.Parameters.AddWithValue("@DriversFront", registrationm.DriversFront);
                cmd.Parameters.AddWithValue("@DriversBack", registrationm.DriversBack);
                cmd.Parameters.AddWithValue("@IdCardFront", registrationm.IdCardFront);
                cmd.Parameters.AddWithValue("@IdCardBack", registrationm.IdCardBack);
                cmd.Parameters.AddWithValue("@PassportFront", registrationm.PassportFront);
                cmd.Parameters.AddWithValue("@TwoFactorAuthLink", registrationm.TwoFactorAuthLink);
                cmd.Parameters.AddWithValue("@TwoFactorAuthStatus", registrationm.TwoFactorAuthStatus);
                cmd.Parameters.AddWithValue("@RegistrationID", registrationm.RegistrationID);

                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                registrationm.errorMessage = "Success";
         

            }
            catch (Exception ee)
            {
                registrationm.errorMessage = ee.ToString();
            }

            return registrationm;
         
        }
      
    }
}