using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RefugeeCamp.Domain.Models
{
    public partial class evenement
    {
        public evenement()
        {
            this.ratings = new List<rating>();
            this.refugees = new List<refugee>();
            this.Volunteers = new List<Volunteer>();
        }

        public int id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> dateEvent { get; set; }
        public string imagename { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public int nbplace { get; set; }
        public Nullable<int> creator_id { get; set; }
        public virtual CampChef Campchef { get; set; }
        public virtual ICollection<rating> ratings { get; set; }
        public virtual ICollection<refugee> refugees { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }

    }
}
