using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class evenement
    {
        public evenement()
        {
            this.ratings = new List<rating>();
            this.refugees = new List<refugee>();
            this.users = new List<user>();
        }

        public int id { get; set; }
        public Nullable<System.DateTime> dateEvent { get; set; }
        public string imagename { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public int nbplace { get; set; }
        public Nullable<int> creator_id { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<rating> ratings { get; set; }
        public virtual ICollection<refugee> refugees { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
