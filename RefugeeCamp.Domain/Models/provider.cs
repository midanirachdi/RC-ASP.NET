using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class provider
    {
        public int id { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string providerName { get; set; }
        public int tel { get; set; }
        public Nullable<int> stock_id { get; set; }
    }
}
