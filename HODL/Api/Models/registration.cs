using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace Api.Models
{
    public class registration
    {

        public string RegistrationID
        {
            get;
            set;
        }
        public int Role
        {
            get;
            set;
        }
        public int CompanyRegNum
        {
            get;
            set;
        }
        public string CompanyName
        {
            get;
            set;
        }

        public int CompanyVat
        {
            get;
            set;
        }
        public int TrustRegNum
        {
            get;
            set;
        }

        public string TrustName 
        {
            get;
            set;
        }
        public string IdentityNumber
        {
            get;
            set;
        }
        public string Passport
        {
            get;
            set;
        }


        public string Name
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }
        public string Province
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }

        public int PostalCode
        {
            get;
            set;
        }

        public string Suburb
        {
            get;
            set;
        }

        public int StreetNumber
        {
            get;
            set;
        }

        public string StreetName
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public int EmailVerified
        {
            get;
            set;
        }

        public int IdVerified
        {
            get;
            set;
        }

        public string TwoFactorAuthLink
        {
            get;
            set;
        }

        public string TwoFactorAuthStatus
        {
            get;
            set;
        }
        public string IdBookFront { get; set; }
        public string DriversFront { get; set; }
        public string DriversBack { get; set; }
        public string IdCardFront { get; set; }
        public string IdCardBack { get; set; }
        public string PassportFront { get; set; }
        public string HoneyCombResult { get; set; }
        public string errorMessage
        {
            get;
            set;
        }
    }
}