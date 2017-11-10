using System;
using System.Collections.Generic;

namespace RefugeeCamp.Domain.Models
{
    public partial class provider
    {
        public provider()
        {
            this.commandes = new List<commande>();
        }

        public int id { get; set; }
        public string adresse { get; set; }
        public string email { get; set; }
        public string nom { get; set; }
        public string tel { get; set; }
        public virtual ICollection<commande> commandes { get; set; }
    }
}
