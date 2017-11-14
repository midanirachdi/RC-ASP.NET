using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class camp
    {
        public camp()
        {
            this.donations = new List<donation>();
            this.refugees = new List<refugee>();
            this.DistrictChefs = new List<DistrictChef>();
        }

        public int id { get; set; }
        public int capacity { get; set; }
        public string country { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
        public string name { get; set; }
        public bool state { get; set; }
        public Nullable<int> campChef_ID { get; set; }
        public virtual ICollection<donation> donations { get; set; }
        public virtual ICollection<refugee> refugees { get; set; }
        public virtual CampChef CampChef { get; set; }
        public virtual ICollection<DistrictChef> DistrictChefs { get; set; }
    }
}
