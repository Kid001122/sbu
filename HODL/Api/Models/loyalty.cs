using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace Api.Models
{
    public class loyalty
    {
        public int LoyaltyId
        {
            get;
            set;
        }

        public string Description
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