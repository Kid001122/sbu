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
    public class friendsreferredUpdateRepository
    {
        public friendsreferred Update(friendsreferred friendsreferredm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Update friendsreferred Set    User = @User,    Email = @Email,    Link = @Link where FriendReferredId=@FriendReferredId";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"User", friendsreferredm.User);
                cmd.Parameters.AddWithValue(@"Email", friendsreferredm.Email);
                cmd.Parameters.AddWithValue(@"Link", friendsreferredm.Link);
                cmd.Parameters.AddWithValue(@"FriendReferredId", friendsreferredm.FriendReferredId);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
                friendsreferredm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                friendsreferredm.errorMessage = ee.ToString();
            }

            return friendsreferredm;
        }
    }
}