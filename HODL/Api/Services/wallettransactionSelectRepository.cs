using Api.Models;
using Api.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Services
{
    public class wallettransactionSelectRepository
    {
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "select * from wallettransaction;";
                var cmd = new MySqlCommand(query, Conn);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
            }
            catch (Exception ee)
            {
                dt.Columns.Add("Error", typeof(string));
                dt.Rows.Add(ee.ToString());
            }

            return dt;
        }
    }
}