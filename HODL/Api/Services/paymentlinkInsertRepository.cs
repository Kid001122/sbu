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
    public class paymentlinkInsertRepository
    {
        public paymentlink Insert(paymentlink paymentlinkm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  paymentlink(PaymentLinkId , User , Wallet , PageName , Amount , Type , PaymentLink , DateCreated , LinkToTransaction , ExtraInfo , ContactInformation ) Values(@PaymentLinkId , @User , @Wallet , @PageName , @Amount , @Type , @PaymentLink , @DateCreated , @LinkToTransaction , @ExtraInfo , @ContactInformation );";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"PaymentLinkId", paymentlinkm.PaymentLinkId);
                cmd.Parameters.AddWithValue(@"User", paymentlinkm.User);
                cmd.Parameters.AddWithValue(@"Wallet", paymentlinkm.Wallet);
                cmd.Parameters.AddWithValue(@"PageName", paymentlinkm.PageName);
                cmd.Parameters.AddWithValue(@"Amount", paymentlinkm.Amount);
                cmd.Parameters.AddWithValue(@"Type", paymentlinkm.Type);
                cmd.Parameters.AddWithValue(@"PaymentLink", paymentlinkm.PaymentLink);
                cmd.Parameters.AddWithValue(@"DateCreated", paymentlinkm.DateCreated);
                cmd.Parameters.AddWithValue(@"LinkToTransaction", paymentlinkm.LinkToTransaction);
                cmd.Parameters.AddWithValue(@"ExtraInfo", paymentlinkm.ExtraInfo);
                cmd.Parameters.AddWithValue(@"ContactInformation", paymentlinkm.ContactInformation);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
                paymentlinkm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                paymentlinkm.errorMessage = ee.ToString();
            }

            return paymentlinkm;
        }
    }
}