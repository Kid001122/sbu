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
    public class loyaltyInsertRepository
    {
        public loyalty Insert(loyalty loyaltym)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  loyalty(LoyaltyId , Description , Type ) Values(@LoyaltyId , @Description , @Type );";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"LoyaltyId", loyaltym.LoyaltyId);
                cmd.Parameters.AddWithValue(@"Description", loyaltym.Description);
                cmd.Parameters.AddWithValue(@"Type", loyaltym.Type);
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