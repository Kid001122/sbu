using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace API.Services
{
    public class loyaltyUpdateRepository
    {
        public loyalty Update(loyalty loyaltym)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Update loyalty Set    Description = @Description,    Type = @Type where LoyaltyId=@LoyaltyId";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"Description", loyaltym.Description);
                cmd.Parameters.AddWithValue(@"Type", loyaltym.Type);
                cmd.Parameters.AddWithValue(@"LoyaltyId", loyaltym.LoyaltyId);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
                loyaltym.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                loyaltym.errorMessage = ee.ToString();
            }

            return loyaltym;
        }
    }
}