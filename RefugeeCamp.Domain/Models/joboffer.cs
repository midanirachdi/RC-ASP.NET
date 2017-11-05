using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class joboffer
    {
        public int id { get; set; }
        public Nullable<System.DateTime> begindate { get; set; }
        public string companyAdress { get; set; }
        public string companyName { get; set; }
        public string contactEmail { get; set; }
        public string contactName { get; set; }
        public int contactnumber { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> enddate { get; set; }
        public string fieldOfWork { get; set; }
        public int salaryEstimate { get; set; }
        public string title { get; set; }
        public Nullable<int> CAMPCHEF_ID { get; set; }
        public Nullable<int> DISTRICTCHEF_ID { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
