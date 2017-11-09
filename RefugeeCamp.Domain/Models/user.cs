using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class user
    {
        public user()
        {
            this.camps = new List<camp>();
            this.comments = new List<comment>();
            this.evenements = new List<evenement>();
            this.joboffers = new List<joboffer>();
            this.joboffers1 = new List<joboffer>();
            this.needs = new List<need>();
            this.tasks = new List<task>();
            this.topics = new List<topic>();
            this.evenements1 = new List<evenement>();
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
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<evenement> evenements { get; set; }
        public virtual ICollection<joboffer> joboffers { get; set; }
        public virtual ICollection<joboffer> joboffers1 { get; set; }
        public virtual ICollection<need> needs { get; set; }
        public virtual ICollection<task> tasks { get; set; }
        public virtual ICollection<topic> topics { get; set; }
        public virtual ICollection<evenement> evenements1 { get; set; }
    }
}
