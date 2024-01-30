using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Api.Classes;
using Api.Models;

namespace API.Services
{
    public class loyaltyDeleteRepository
    {
        public DeleteModel Delete(DeleteModel DeleteModelm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Delete  from loyalty where LoyaltyId= @LoyaltyId";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"LoyaltyId", DeleteModelm.DeleteId);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
                DeleteModelm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                DeleteModelm.errorMessage = ee.ToString();
            }

            return DeleteModelm;
        }
    }
}