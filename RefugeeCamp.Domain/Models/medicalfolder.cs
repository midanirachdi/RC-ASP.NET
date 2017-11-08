using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class medicalfolder
    {
        public medicalfolder()
        {
            this.refugees = new List<refugee>();
        }

        public int id { get; set; }
        public string apparences { get; set; }
        public float bloodpressure { get; set; }
        public string bloodtype { get; set; }
        public string description { get; set; }
        public string doctorname { get; set; }
        public float height { get; set; }
        public string mentalstate { get; set; }
        public float weight { get; set; }
        public virtual ICollection<refugee> refugees { get; set; }
    }
}
