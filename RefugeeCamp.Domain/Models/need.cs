using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class need
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int status { get; set; }
        public string type { get; set; }
        public Nullable<int> iddcchef { get; set; }
        public virtual user user { get; set; }
    }
}
