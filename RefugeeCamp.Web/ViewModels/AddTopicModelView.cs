using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Web.ViewModels
{
    public class AddTopicModelView
    {
        public topic topic { get; set; }
        public string tagString { get; set; }
    }
}