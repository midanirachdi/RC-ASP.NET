using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class user
    {
        public user()
        {
            this.camps = new List<camp>();
            this.joboffers = new List<joboffer>();
            this.joboffers1 = new List<joboffer>();
            this.needs = new List<need>();
        }

        public string role { get; set; }
        public int id { get; set; }
        public string adress { get; set; }
        public Nullable<System.DateTime> birthDay { get; set; }
        public bool disable { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string lastResetQuery { get; set; }
        public string password { get; set; }
        public Nullable<int> camp_ID { get; set; }
        public virtual ICollection<camp> camps { get; set; }
        public virtual camp camp { get; set; }
        public virtual ICollection<joboffer> joboffers { get; set; }
        public virtual ICollection<joboffer> joboffers1 { get; set; }
        public virtual ICollection<need> needs { get; set; }
    }
}