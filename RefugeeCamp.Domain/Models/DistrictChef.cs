using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeeCamp.Domain.Models
{
    public class DistrictChef:user
    {
        public DistrictChef():base()
        {
            this.joboffers = new List<joboffer>();
            this.needs = new List<need>();
        }



        public Nullable<int> camp_ID { get; set; }
        public virtual camp camp { get; set; }
        public virtual ICollection<joboffer> joboffers { get; set; }

        public virtual ICollection<need> needs { get; set; }
    }
}
