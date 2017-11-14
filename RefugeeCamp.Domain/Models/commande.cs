using System;
using System.Collections.Generic;

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
        public Nullable<int> Admin { get; set; }
        public Nullable<int> Product { get; set; }
        public Nullable<int> Stock { get; set; }
        public virtual stock stock1 { get; set; }
        public virtual user user { get; set; }
        public virtual product product1 { get; set; }
    }
}
