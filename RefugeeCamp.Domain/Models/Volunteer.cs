﻿using System;
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
            this.evenements1 = new List<evenement>();
        }

        public virtual ICollection<evenement> evenements1 { get; set; }
    }
}
