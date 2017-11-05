using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class medium
    {
        public medium()
        {
            this.news = new List<news>();
        }

        public int id { get; set; }
        public string path { get; set; }
        public string title { get; set; }
        public virtual ICollection<news> news { get; set; }
    }
}
