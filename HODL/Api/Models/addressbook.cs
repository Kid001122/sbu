using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace Api.Models
{
    public class addressbook
    {
        public int AddressBookId
        {
            get;
            set;
        }

        public string Asset
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        public int AccountID
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public DateTime DateAdded
        {
            get;
            set;
        }

        public string Type
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