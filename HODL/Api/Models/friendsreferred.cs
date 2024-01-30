using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Api.Classes;

namespace Api.Models
{
    public class friendsreferred
    {
        public int FriendReferredId
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Link
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