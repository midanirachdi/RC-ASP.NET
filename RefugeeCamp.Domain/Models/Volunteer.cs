using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeeCamp.Domain.Models
{
    public class Volunteer:user
    {
        public Volunteer():base()
        {
            this.events = new List<evenement>();
        }

        public virtual ICollection<evenement> events { get; set; }
    }
}
