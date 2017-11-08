using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class tag
    {
        public tag()
        {
            this.topics = new List<topic>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<topic> topics { get; set; }
    }
}
