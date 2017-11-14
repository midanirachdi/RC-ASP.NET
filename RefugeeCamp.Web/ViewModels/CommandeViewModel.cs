using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RefugeeCamp.Web.ViewModels
{
    public class CommandeViewModel
    {
        public string address { get; set; }
        public string country { get; set; }
        public int qteOfProduct { get; set; }

        public virtual string ProviderID { get; set; }

        public virtual SelectList ProviderList { get; set; }
    }
}