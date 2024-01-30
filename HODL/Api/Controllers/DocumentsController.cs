using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using API.Classes;
using Api.Classes;

namespace API.Controllers
{
    public class DocumentsController : ApiController
    {
        // GET: Groups
        

        //[MimeMultipart]
        public async Task<FileUploadResult> Post()
        {
            var re = Request;
            var headers = re.Headers;

            try
            {

                if (headers.Contains("Type"))
                {
                    try
                    {
                        string Username = headers.GetValues("Username").First();
                        var uploadPath = @"C:\Development\Files";

                        var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath+@"\"+Username);
                        
                        string _localFileName = "";
                        await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);
                        _localFileName = multipartFormDataStreamProvider
                    .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();
                        string Type = headers.GetValues("Type").First();
                        
                        string UserID = headers.GetValues("UserID").First();
                        string DocumentName = headers.GetValues("DocumentName").First();
                        string DocumentDescription = headers.GetValues("DocumentDescription").First();
                       
                    }
                    catch (Exception ee)
                    {
                        ErrorLogger EL = new ErrorLogger();
                        EL.ExecuteQueryMYSQL(ee.ToString());

                        System.IO.File.WriteAllText(@"C:\Development\LogFiles\Documents3.txt", ee.ToString());
                    }

                }
               
            }
            catch (Exception ee)
            {
                System.IO.File.WriteAllText(@"C:\Development\LogFiles\Documents.txt", ee.ToString());
            }
            return null;
        }
    }
}