using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RefugeeCamp.Domain.Models
{
    public partial class task
    {
        public int id { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "End date")]
        public Nullable<System.DateTime> endDate { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Progress")]
        public int progress { get; set; } = 0;
        [Display(Name = "Start date")]
        public Nullable<System.DateTime> startDate { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        [Display(Name = "User")]
        public Nullable<int> UserId { get; set; }
        public virtual user user { get; set; }
    }
}
