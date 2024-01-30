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
    public class benefitsInsertRepository
    {
        public benefits Insert(benefits benefitsm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  benefits(BenefitId , Description , FirstFieldPercentage , SecondFieldPercentage , ThirdFieldPercentage , FouthFieldPercentage ) Values(@BenefitId , @Description , @FirstFieldPercentage , @SecondFieldPercentage , @ThirdFieldPercentage , @FouthFieldPercentage );";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"BenefitId", benefitsm.BenefitId);
                cmd.Parameters.AddWithValue(@"Description", benefitsm.Description);
                cmd.Parameters.AddWithValue(@"FirstFieldPercentage", benefitsm.FirstFieldPercentage);
                cmd.Parameters.AddWithValue(@"SecondFieldPercentage", benefitsm.SecondFieldPercentage);
                cmd.Parameters.AddWithValue(@"ThirdFieldPercentage", benefitsm.ThirdFieldPercentage);
                cmd.Parameters.AddWithValue(@"FouthFieldPercentage", benefitsm.FouthFieldPercentage);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
                benefitsm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                benefitsm.errorMessage = ee.ToString();
            }

            return benefitsm;
        }
    }
}