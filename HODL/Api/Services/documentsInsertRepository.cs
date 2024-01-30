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
    public class documentsInsertRepository
    {
        public documents Insert(documents documentsm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  documents(DocumentId , Type , User , Url , StoreSelfiePicture ) Values(@DocumentId , @Type , @User , @Url , @StoreSelfiePicture );";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"DocumentId", documentsm.DocumentId);
                cmd.Parameters.AddWithValue(@"Type", documentsm.Type);
                cmd.Parameters.AddWithValue(@"User", documentsm.User);
                cmd.Parameters.AddWithValue(@"Url", documentsm.Url);
                cmd.Parameters.AddWithValue(@"StoreSelfiePicture", documentsm.StoreSelfiePicture);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
                documentsm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                documentsm.errorMessage = ee.ToString();
            }

            return documentsm;
        }
    }
}