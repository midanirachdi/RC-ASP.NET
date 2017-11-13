using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public abstract partial class user
    {
        public user()
        {
     
        }


        public int id { get; set; }
        public string adress { get; set; }
        public Nullable<System.DateTime> birthDay { get; set; }
        public bool disable { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string lastResetQuery { get; set; }
        public string password { get; set; }
        public string FullName { get { return firstName + " " + lastName; } }


    }
}
