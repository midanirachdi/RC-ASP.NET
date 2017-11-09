using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class stocknotification
    {
        public int id { get; set; }
        public Nullable<System.DateTime> dateOfNotification { get; set; }
        public string message { get; set; }
        public int status { get; set; }
        public Nullable<int> StockId { get; set; }
        public virtual stock stock { get; set; }
    }
}
