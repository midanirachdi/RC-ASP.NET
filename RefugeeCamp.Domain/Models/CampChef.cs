using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeeCamp.Domain.Models
{
    public class CampChef:user
    {
        public CampChef()
        {
            this.joboffers = new List<joboffer>();
            this.evenements = new List<evenement>();
        }

        public virtual ICollection<joboffer> joboffers { get; set; }
        public virtual ICollection<evenement> evenements { get; set; }

    }
}
