﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;
using RefugeeCamp.Web.Security;
using RefugeeCamp.Web.ViewModels;

namespace RefugeeCamp.Web.Controllers
{
    public class TopicController : Controller
    {
        GestionTopic gt = new GestionTopic();
        GestionComment gc=new GestionComment();
        // GET: Topic
        public ActionResult Index()
        {  
            TopicListView tlv=new TopicListView();
    
            tlv.ListTopic = gt.getAllTopics();
            return View("ListTopic",tlv);
        }


        public ActionResult TopicItem(topic topic)
        {
            return PartialView("TopicItem",topic);
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult ShowTopic(int id)
        {
            topic t = gt.QueryObjectGraph("user").FirstOrDefault();
            TopicShowViewModel tsvm = new TopicShowViewModel
            {
                topic = t,
            };
  
            return View("ShowTopic",tsvm);
        }


        public ActionResult UpdateTopic(int id)
        {
            topic t = gt.FindById(id);
            t.closed = !t.closed;
            gt.Update(t);
            gt.Commit();
            return RedirectToAction("ShowTopic", "Topic",new{id= t.id});
        }


        public ActionResult AddTopic()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTopic(AddTopicModelView t)
        {
            t.topic.User_ID = SessionPersister.User.id;
            gt.Create(t.topic);
            gt.Commit();
            return View();
        }
    }
}