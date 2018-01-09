using System;
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
        GestionTag gtag=new GestionTag();

        [CustomAuthorize(Roles = "Admin,CampChef,DistrictChef,Volunteer")]
        public ActionResult Index()
        {  
            TopicListView tlv=new TopicListView();
    
            tlv.ListTopic = gt.getAllTopics();
            return View("ListTopic",tlv);
        }


        public ActionResult TopicItem(topic topic)
        {
            return View("TopicItem",topic);
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult ShowTopic(int id)
        {
            topic t = gt.FindById(id);
          //  List<comment> comments = gc.FindByCondition(e => e.topic.id == id).ToList();
          //  t.comments = comments;
            TopicShowViewModel tsvm = new TopicShowViewModel
            {
                topic = t,
            };
  
            return View("ShowTopic",tsvm);
        }

        [CustomAuthorize(Roles = "Admin,CampChef,DistrictChef,Volunteer")]
        public ActionResult UpdateTopic(int id)
        {
            topic t = gt.FindById(id);
            t.closed = !t.closed;
            gt.Update(t);
            gt.Commit();
            return RedirectToAction("ShowTopic", "Topic",new{id= t.id});
        }


        [CustomAuthorize(Roles = "Admin,CampChef,DistrictChef,Volunteer")]
        public ActionResult SearchTopic(string str)
        {
            TopicListView tlv=new TopicListView();
            tlv.ListTopic = gt.Search(str);
            

            return View("ListTopic",tlv);
        }


        [CustomAuthorize(Roles = "CampChef,DistrictChef,Volunteer")]
        public ActionResult AddTopic()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [CustomAuthorize(Roles = "CampChef,DistrictChef,Volunteer")]
        public ActionResult AddTopic(AddTopicModelView t)
        {
            string[] tags;
            t.topic.User_ID = SessionPersister.User.id;
            if(t.tagString!=null)
            {  tags= t.tagString.Split(',');
            foreach (var s in tags)
            {
                tag tmp = gtag.FindByCondition(e => e.name.Equals(s.ToUpper())).FirstOrDefault();
                if(tmp ==null)
                t.topic.tags.Add(new tag{name=s.ToUpper()});
                else
                {
                    t.topic.tags.Add(tmp);
                }
            }
            }
          
            gt.Create(t.topic);
            gt.Commit();
            return RedirectToAction("Index");
        }
    }
}