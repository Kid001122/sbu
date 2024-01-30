using Api.Models;
using Api.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Api.Models;

namespace API.Services
{
    public class documentsFilterSelectRepository
    {
        public DataTable Select(FilterModel FilterModelM)
        {
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "";
                if (FilterModelM.maxRecordsCount <= 0)
                {
                    query = "select * from documents where " + FilterModelM.FilterColumnName + " ='" + FilterModelM.FilterColumnValue + "' ";
                }
                else
                {
                    query = "select  top(" + FilterModelM.maxRecordsCount + ") * from documents where " + FilterModelM.FilterColumnName + " ='" + FilterModelM.FilterColumnValue + "' ";
                }

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