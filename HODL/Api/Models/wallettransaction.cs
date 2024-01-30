using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace Api.Models
{
    public class wallettransaction
    {
        public int WalletID
        {
            get;
            set;
        }

        public string WalletTransactionId
        {
            get;
            set;
        }

        public string FromAccount
        {
            get;
            set;
        }

        public string ToAccount
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public string Network
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public decimal NetworkFee
        {
            get;
            set;
        }

        public decimal HODLFee
        {
            get;
            set;
        }

        public string Status
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