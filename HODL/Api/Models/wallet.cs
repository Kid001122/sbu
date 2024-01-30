using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace Api.Models
{
    public class wallet
    {
        public int WalletID
        {
            get;
            set;
        }

        public string WalletName
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public int MainAccount
        {
            get;
            set;
        }

        public string CryptoWalletID
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