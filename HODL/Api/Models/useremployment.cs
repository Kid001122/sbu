using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace Api.Models
{
    public class useremployment
    {
        public int UserEmploymentId
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        public string NameOfBusiness
        {
            get;
            set;
        }

        public string EmploymentStatus
        {
            get;
            set;
        }

        public string SourceOfFund
        {
            get;
            set;
        }

        public string SourceOfCrypto
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