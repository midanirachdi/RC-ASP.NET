using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class product
    {
        public product()
        {
            this.commandes = new List<commande>();
        }

        public int id { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string productName { get; set; }
        public virtual ICollection<commande> commandes { get; set; }
    }
}
