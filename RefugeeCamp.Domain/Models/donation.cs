using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class donation
    {
        public string id { get; set; }
        public double amount { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
        public string currency { get; set; }
        public string state { get; set; }
        public Nullable<System.DateTime> validatedAt { get; set; }
        public Nullable<int> camp_ID { get; set; }
        public virtual camp camp { get; set; }
    }
}
