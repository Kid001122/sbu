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
    public class walletInsertRepository
    {
        public wallet Insert(wallet walletm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  wallet(WalletID , WalletName , User , Amount , MainAccount , CryptoWalletID ) Values(@WalletID , @WalletName , @User , @Amount , @MainAccount , @CryptoWalletID );";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"WalletID", walletm.WalletID);
                cmd.Parameters.AddWithValue(@"WalletName", walletm.WalletName);
                cmd.Parameters.AddWithValue(@"User", walletm.User);
                cmd.Parameters.AddWithValue(@"Amount", walletm.Amount);
                cmd.Parameters.AddWithValue(@"MainAccount", walletm.MainAccount);
                cmd.Parameters.AddWithValue(@"CryptoWalletID", walletm.CryptoWalletID);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
                walletm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                walletm.errorMessage = ee.ToString();
            }

            return walletm;
        }
    }
}