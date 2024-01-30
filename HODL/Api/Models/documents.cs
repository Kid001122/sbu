using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace Api.Models
{
    public class documents
    {
        public int DocumentId
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public byte[] StoreSelfiePicture
        {
            get;
            set;
        }

        public string errorMessage
        {
            get;
            set;
        }
    }
}