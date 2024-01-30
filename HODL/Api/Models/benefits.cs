using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace Api.Models
{
    public class benefits
    {
        public int BenefitId
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public decimal FirstFieldPercentage
        {
            get;
            set;
        }

        public decimal SecondFieldPercentage
        {
            get;
            set;
        }

        public decimal ThirdFieldPercentage
        {
            get;
            set;
        }

        public decimal FouthFieldPercentage
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