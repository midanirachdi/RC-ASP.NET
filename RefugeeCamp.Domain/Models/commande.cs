using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RefugeeCamp.Domain.Models
{
    public partial class commande
    {
        public int id { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public Nullable<System.DateTime> ordered { get; set; }
        public int qteOfProduct { get; set; }
        public Nullable<System.DateTime> shipped { get; set; }
        public int status { get; set; }
        public double totalPrice { get; set; }
        [ForeignKey("Admin1")]
        public Nullable<int> Admin { get; set; }
        public Nullable<int> Product { get; set; }
        public Nullable<int> Provider { get; set; }
        public Nullable<int> Stock { get; set; }
        public virtual provider provider1 { get; set; }
        public virtual stock stock1 { get; set; }
        public virtual Admin Admin1 { get; set; }
        public virtual product product1 { get; set; }
    }
}
