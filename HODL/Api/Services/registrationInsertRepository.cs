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

namespace API.Services
{
    public class registrationInsertRepository
    {
        public registration Insert(registration registrationm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "INSERT INTO registration (registrationID, Role, CompanyRegNum, CompanyName, CompanyVat, TrustRegNum, TrustName, IdentityNumber, Passport, Name, LastName, MiddleName, Email, " +
                    "Password, City, Province, Country, PostalCode, Suburb, StreetNumber, StreetName, PhoneNumber, EmailVerified, IdVerified, TwoFactorAuthLink, TwoFactorAuthStatus, DriversFront, DriversBack, IdCardFront, IdCardBack, PassportFront)" +
                    " VALUES (@registrationID, @Role, @CompanyRegNum, @CompanyName, @CompanyVat, @TrustRegNum, @TrustName, @IdentityNumber, @Passport, @Name, @LastName, @MiddleName, @Email, " +
                    "@Password, @City, @Province, @Country, @PostalCode, @Suburb, @StreetNumber, @StreetName, @PhoneNumber, @EmailVerified, @IdVerified, @TwoFactorAuthLink, @TwoFactorAuthStatus, @DriversFront, @DriversBack, @IdCardFront, @IdCardBack, @PassportFront)";

                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"registrationID", registrationm.RegistrationID);
                cmd.Parameters.AddWithValue(@"Role", registrationm.Role);
                cmd.Parameters.AddWithValue(@"CompanyRegNum", registrationm.CompanyRegNum);
                cmd.Parameters.AddWithValue(@"CompanyName", registrationm.CompanyName);
                cmd.Parameters.AddWithValue(@"CompanyVat", registrationm.CompanyVat);
                cmd.Parameters.AddWithValue(@"TrustRegNum", registrationm.TrustRegNum);
                cmd.Parameters.AddWithValue(@"TrustName", registrationm.TrustName);
                cmd.Parameters.AddWithValue(@"IdentityNumber", registrationm.IdentityNumber);
                cmd.Parameters.AddWithValue(@"Passport", registrationm.Passport);
                cmd.Parameters.AddWithValue(@"Name", registrationm.Name);
                cmd.Parameters.AddWithValue(@"LastName", registrationm.LastName);
                cmd.Parameters.AddWithValue(@"MiddleName", registrationm.MiddleName);
                cmd.Parameters.AddWithValue(@"Email", registrationm.Email);
                cmd.Parameters.AddWithValue(@"Password", registrationm.Password);
                cmd.Parameters.AddWithValue(@"City", registrationm.City);
                cmd.Parameters.AddWithValue(@"Province", registrationm.Province);
                cmd.Parameters.AddWithValue(@"Country", registrationm.Country);
                cmd.Parameters.AddWithValue(@"PostalCode", registrationm.PostalCode);
                cmd.Parameters.AddWithValue(@"Suburb", registrationm.Suburb);
                cmd.Parameters.AddWithValue(@"StreetNumber", registrationm.StreetNumber);
                cmd.Parameters.AddWithValue(@"StreetName", registrationm.StreetName);
                cmd.Parameters.AddWithValue(@"PhoneNumber", registrationm.PhoneNumber);
                cmd.Parameters.AddWithValue(@"EmailVerified", registrationm.EmailVerified);
                cmd.Parameters.AddWithValue(@"IdVerified", registrationm.IdVerified);
                cmd.Parameters.AddWithValue(@"TwoFactorAuthLink", registrationm.TwoFactorAuthLink);
                cmd.Parameters.AddWithValue("@DriversFront", registrationm.DriversFront);
                cmd.Parameters.AddWithValue("@DriversBack", registrationm.DriversBack);
                cmd.Parameters.AddWithValue("@IdCardFront", registrationm.IdCardFront);
                cmd.Parameters.AddWithValue("@IdCardBack", registrationm.IdCardBack);
                cmd.Parameters.AddWithValue("@PassportFront", registrationm.PassportFront);
                cmd.Parameters.AddWithValue(@"TwoFactorAuthStatus", registrationm.TwoFactorAuthStatus);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
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