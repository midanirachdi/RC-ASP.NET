using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class stock
    {
        public stock()
        {
            this.stocknotifications = new List<stocknotification>();
        }

        public int stock_id { get; set; }
        public string notes { get; set; }
        public int qteInStock { get; set; }
        public int qteTotal { get; set; }
        public string stockType { get; set; }
        public double stockValue { get; set; }
        public virtual ICollection<stocknotification> stocknotifications { get; set; }
    }
}
