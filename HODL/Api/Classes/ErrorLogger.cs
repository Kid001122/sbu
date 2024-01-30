using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Api.Classes
{
    public class ErrorLogger
    {

        public DataTable ExecuteQueryMYSQL(string ErrorMessage)
        {

            string queryTable = @"CREATE TABLE `phpapplo_pcf`.`errorlog` (
                              `ErrorLogID` INT NOT NULL AUTO_INCREMENT,
                              `ErrorTime` DATETIME NULL,
                              `ErrorMessage` VARCHAR(45) NULL,
                              PRIMARY KEY (`ErrorLogID`));
                            ";
            string connstring1 = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultMYSQLConnection"].ConnectionString;
            MySqlConnection Conn1 = new MySqlConnection(connstring1);
            try
            {
                Conn1.Open();
                string query = queryTable;
                var cmd = new MySqlCommand(queryTable,  Conn1);
                cmd.ExecuteReader();
                Conn1.Close();
            }
            catch (Exception)
            {
               
            }
            DataTable dt = new DataTable();
            try
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultMYSQLConnection"].ConnectionString;
                MySqlConnection Conn = new MySqlConnection(connstring);
                try
                {
                    Conn.Open();
                    //string query = Query;
                    var cmd = new MySqlCommand(@"INSERT INTO `errorlog`
                            (
                            `ErrorTime`,
                            `ErrorMessage`)
                            VALUES
                            ('" + DateTime.Now + "','" + ErrorMessage + "')", Conn1);
                    cmd.ExecuteReader();
                    Conn.Close();
                }
                catch (Exception)
                {
                  
                }

            }
            catch (Exception)
            {
            }
            return dt;

        }
        public DataTable ExecuteQuerySQL(string ErrorMessage)
        {
            string queryTable = @"GO
                SET QUOTED_IDENTIFIER ON
                GO
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorLog]') AND type in (N'U'))
                BEGIN

                CREATE TABLE [dbo].[ErrorLog](
	                [ErrorLogID] [int] IDENTITY(1,1) NOT NULL,
	                [ErrorTime] [datetime] NOT NULL CONSTRAINT [DF_ErrorLog_ErrorTime]  DEFAULT (getdate()),
	                [ErrorMessage] [nvarchar](4000) NOT NULL,
                ) ON [PRIMARY]

                END
                GO";
            string connstring1 = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultSQLConnection"].ConnectionString;
            SqlConnection Conn1 = new SqlConnection(connstring1);
            try
            {
                Conn1.Open();
               
                var cmd = new SqlCommand(queryTable, Conn1);
                cmd.ExecuteReader();
                Conn1.Close();
            }
            catch (Exception)
            {

            }
            DataTable dt = new DataTable();
            try
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultSQLConnection"].ConnectionString;
                SqlConnection Conn = new SqlConnection(connstring);
                try
                {
                    Conn.Open();
                    
                    var cmd = new SqlCommand(@"INSERT INTO [dbo].[ErrorLog]
                                             ([ErrorMessage]) VALUES('"+ErrorMessage+"')GO", Conn);
                   cmd.ExecuteReader();
                    Conn.Close();
                }
                catch (Exception)
                {

                }

            }
            catch (Exception)
            {
            }
            return dt;

        }
    }
}