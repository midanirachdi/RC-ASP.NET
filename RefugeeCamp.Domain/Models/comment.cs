using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RefugeeCamp.Domain.Models
{
    public partial class comment
    {
        public int id { get; set; }

        [Column(TypeName = "Text")]
        public string body { get; set; }
        public Nullable<System.DateTime> datePublish { get; set; }
        public Nullable<int> Topic_ID { get; set; }

        [ForeignKey("user")]
        public Nullable<int> User_ID { get; set; }
        public virtual topic topic { get; set; }

   
        public virtual user user { get; set; }
    }
}
