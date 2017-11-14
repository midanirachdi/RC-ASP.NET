using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class rating
    {
        public int idEvent { get; set; }
        public int idVolunteer { get; set; }
        public Nullable<System.DateTime> dateOfRating { get; set; }
        public int mark { get; set; }
        public virtual evenement evenement { get; set; }
        public virtual user user { get; set; }
    }
}
