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
    public class addressbookInsertRepository
    {
        public addressbook Insert(addressbook addressbookm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  addressbook(AddressBookId , Asset , User , AccountID , Description , DateAdded , Type ) Values(@AddressBookId , @Asset , @User , @AccountID , @Description , @DateAdded , @Type );";
                var cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"AddressBookId", addressbookm.AddressBookId);
                cmd.Parameters.AddWithValue(@"Asset", addressbookm.Asset);
                cmd.Parameters.AddWithValue(@"User", addressbookm.User);
                cmd.Parameters.AddWithValue(@"AccountID", addressbookm.AccountID);
                cmd.Parameters.AddWithValue(@"Description", addressbookm.Description);
                cmd.Parameters.AddWithValue(@"DateAdded", addressbookm.DateAdded);
                cmd.Parameters.AddWithValue(@"Type", addressbookm.Type);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                i = 1;
                addressbookm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                addressbookm.errorMessage = ee.ToString();
            }

            return addressbookm;
        }
    }
}