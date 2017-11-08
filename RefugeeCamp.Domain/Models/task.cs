using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class task
    {
        public int id { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public string status { get; set; }
        public int? UserId { get; set; }
        public virtual user user { get; set; }
    }
}
