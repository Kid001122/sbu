using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace Api.Models
{
    public class paymentlink
    {
        public int PaymentLinkId
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        public string Wallet
        {
            get;
            set;
        }

        public string PageName
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string PaymentLink
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        public string LinkToTransaction
        {
            get;
            set;
        }

        public string ExtraInfo
        {
            get;
            set;
        }

        public string ContactInformation
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