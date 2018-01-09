using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Web.Security
{
    public class CustomPrincipal : IPrincipal
    {

        private user User;


        public CustomPrincipal(user user)
        {
            this.User = user;
            this.Identity = new GenericIdentity(user.email);
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.User.GetType().Name.Equals(r));
        }
    }
}