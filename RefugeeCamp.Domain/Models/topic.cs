using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RefugeeCamp.Domain.Models
{
    public partial class topic
    {
        public topic()
        {
            this.comments = new List<comment>();
            this.tags = new List<tag>();
        }

        public int id { get; set; }

        [Column(TypeName = "Text")]
        public string body { get; set; }
        public bool closed { get; set; }
        public Nullable<System.DateTime> datePublish { get; set; }
        public string title { get; set; }
        public Nullable<int> User_ID { get; set; }
        public virtual ICollection<comment> comments { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<tag> tags { get; set; }
    }
}
