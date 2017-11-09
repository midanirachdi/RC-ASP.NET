using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class refugee
    {
        public refugee()
        {
            this.evenements = new List<evenement>();
        }

        public int id { get; set; }
        public string adress { get; set; }
        public Nullable<System.DateTime> dateOfBirth { get; set; }
        public string email { get; set; }
        public string englishlanguageLevel { get; set; }
        public string fieldOfWork { get; set; }
        public string firstname { get; set; }
        public string frenchlanguageLevel { get; set; }
        public string highestDegree { get; set; }
        public string lastName { get; set; }
        public string nationality { get; set; }
        public int phoneNumber { get; set; }
        public string sex { get; set; }
        public int yearsOfExperience { get; set; }
        public Nullable<int> fiche_ID { get; set; }
        public Nullable<int> camp_ID { get; set; }
        public virtual camp camp { get; set; }
        public virtual medicalfolder medicalfolder { get; set; }
        public virtual ICollection<evenement> evenements { get; set; }
    }
}
