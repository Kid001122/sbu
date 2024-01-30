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
    public class wallettransactionInsertRepository
    {
        public wallettransaction Insert(wallettransaction wallettransactionm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  wallettransaction(WalletID , WalletTransactionId , FromAccount , ToAccount , Amount , Network , Description , NetworkFee , HODLFee , Status , Type ) Values(@WalletID , @WalletTransactionId , @FromAccount , @ToAccount , @Amount , @Network , @Description , @NetworkFee , @HODLFee , @Status , @Type );";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"WalletID", wallettransactionm.WalletID);
                cmd.Parameters.AddWithValue(@"WalletTransactionId", wallettransactionm.WalletTransactionId);
                cmd.Parameters.AddWithValue(@"FromAccount", wallettransactionm.FromAccount);
                cmd.Parameters.AddWithValue(@"ToAccount", wallettransactionm.ToAccount);
                cmd.Parameters.AddWithValue(@"Amount", wallettransactionm.Amount);
                cmd.Parameters.AddWithValue(@"Network", wallettransactionm.Network);
                cmd.Parameters.AddWithValue(@"Description", wallettransactionm.Description);
                cmd.Parameters.AddWithValue(@"NetworkFee", wallettransactionm.NetworkFee);
                cmd.Parameters.AddWithValue(@"HODLFee", wallettransactionm.HODLFee);
                cmd.Parameters.AddWithValue(@"Status", wallettransactionm.Status);
                cmd.Parameters.AddWithValue(@"Type", wallettransactionm.Type);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
                wallettransactionm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                wallettransactionm.errorMessage = ee.ToString();
            }

            return wallettransactionm;
        }
    }
}