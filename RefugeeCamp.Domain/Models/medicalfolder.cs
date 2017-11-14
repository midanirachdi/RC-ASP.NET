using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RefugeeCamp.Domain.Models
{
    public partial class medicalfolder
    {
        public medicalfolder()
        {
            this.refugees = new List<refugee>();
        }

        public int id { get; set; }
        [MaxLength(50)]
        public string apparences { get; set; }
        public float bloodpressure { get; set; }
        public string bloodtype { get; set; }
        public string description { get; set; }
        [Required(ErrorMessage = "please to choose a doctor")]
        public string doctorname { get; set; }
        [Required(ErrorMessage = "Refugee height is required")]
        public float height { get; set; }
        public string mentalstate { get; set; }
        [Required(ErrorMessage = "Refugee weight is required")]
        public float weight { get; set; }
        public virtual ICollection<refugee> refugees { get; set; }
    }
}
