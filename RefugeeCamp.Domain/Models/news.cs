using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class news
    {
        public news()
        {
            this.media = new List<medium>();
        }

        public int id { get; set; }
        public string author { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> dateOfCreation { get; set; }
        public Nullable<int> AdminId { get; set; }
        public virtual ICollection<medium> media { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
