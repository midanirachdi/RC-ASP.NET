using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Web.ViewModels
{
    public class TopicShowViewModel
    {
        public topic topic { get; set; }
        public string newComment { get; set; }
    }
}