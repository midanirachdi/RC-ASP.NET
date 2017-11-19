using RefugeeCamp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefugeeCamp.Web.ViewModels
{
    public class CommandeViewModel
    {
        public commande Commande { get; set; }
        public int PostedProviderId { get; set; }
    }
}