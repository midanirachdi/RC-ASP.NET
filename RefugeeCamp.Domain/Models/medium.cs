using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class medium
    {
        public int id { get; set; }
        public string path { get; set; }
        public string title { get; set; }
        public Nullable<int> NewsId { get; set; }
        public virtual news news { get; set; }
    }
}
