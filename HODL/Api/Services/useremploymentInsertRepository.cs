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
    public class useremploymentInsertRepository
    {
        public useremployment Insert(useremployment useremploymentm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  useremployment(UserEmploymentId , User , NameOfBusiness , EmploymentStatus , SourceOfFund , SourceOfCrypto ) Values(@UserEmploymentId , @User , @NameOfBusiness , @EmploymentStatus , @SourceOfFund , @SourceOfCrypto );";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"UserEmploymentId", useremploymentm.UserEmploymentId);
                cmd.Parameters.AddWithValue(@"User", useremploymentm.User);
                cmd.Parameters.AddWithValue(@"NameOfBusiness", useremploymentm.NameOfBusiness);
                cmd.Parameters.AddWithValue(@"EmploymentStatus", useremploymentm.EmploymentStatus);
                cmd.Parameters.AddWithValue(@"SourceOfFund", useremploymentm.SourceOfFund);
                cmd.Parameters.AddWithValue(@"SourceOfCrypto", useremploymentm.SourceOfCrypto);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
                useremploymentm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                useremploymentm.errorMessage = ee.ToString();
            }

            return useremploymentm;
        }
    }
}