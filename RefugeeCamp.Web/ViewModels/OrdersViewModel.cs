using RefugeeCamp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefugeeCamp.Web.ViewModels
{
    public class OrdersViewModel
    {
        public commande Cmd { get; set; }
        public string AdminName{ get; set; }
        public string ProviderName { get; set; }
        public string StockType { get; set; }
    }
}