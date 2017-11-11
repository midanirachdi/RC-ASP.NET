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
        }

        public virtual ICollection<joboffer> joboffers { get; set; }
    }
}
