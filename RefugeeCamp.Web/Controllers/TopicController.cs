using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;
using RefugeeCamp.Web.ViewModels;

namespace RefugeeCamp.Web.Controllers
{
    public class TopicController : Controller
    {
        // GET: Topic
        public ActionResult Index()
        {  
            TopicListView tlv=new TopicListView();
            GestionTopic gt=new GestionTopic();
            tlv.ListTopic = gt.getAllTopics();
            return View("ListTopic",tlv);
        }


        public ActionResult TopicItem(topic topic)
        {
            return PartialView("TopicItem",topic);
        }
    }
}