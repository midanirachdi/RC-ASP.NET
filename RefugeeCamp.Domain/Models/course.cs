using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class course
    {
        public course()
        {

        }
        public int id { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> enddate { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> startdate { get; set; }
        public Nullable<int> iddcchef { get; set; }
        public virtual DistrictChef DistrictChef { get; set; }
    }
}
