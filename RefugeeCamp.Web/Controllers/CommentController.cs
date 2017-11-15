using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;
using RefugeeCamp.Web.Security;
using RefugeeCamp.Web.ViewModels;

namespace RefugeeCamp.Web.Controllers
{
    public class CommentController : Controller
    {
        GestionComment gc=new GestionComment();
        GestionTopic gt=new GestionTopic();

       
        [ValidateInput(false)]
        [HttpPost]
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult AddCommentToTopic(TopicShowViewModel tsvp)
        {
            comment c=new comment();
           /* c.topic = gt.FindById(tsvp.topic.id);
            c.user = SessionPersister.User;*/
            c.Topic_ID = tsvp.topic.id;
            c.User_ID = SessionPersister.User.id;
            c.body =tsvp.newComment;
            gc.Create(c);
            gc.Commit();
            
            return RedirectToAction("ShowTopic", "Topic", new {id = tsvp.topic.id});
        }



        public ActionResult CommentItem(comment comment)
        {
            return PartialView("CommentItem", comment);
        }
    }
}