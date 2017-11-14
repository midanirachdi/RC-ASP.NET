using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Web.Security
{
    public static class SessionPersister
    {
        private static string userSessionVar = "user";
        private static string tokenUser = "token";

        public static string Token
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                var sessionVar = HttpContext.Current.Session[tokenUser];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }


            set { HttpContext.Current.Session[tokenUser] = value; }
        }

        public static user User
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                var sessionVar = HttpContext.Current.Session[userSessionVar];
                if (sessionVar != null)
                    return sessionVar as user;
                return null;
            }


            set { HttpContext.Current.Session[userSessionVar] = value; }
        }
    }
}