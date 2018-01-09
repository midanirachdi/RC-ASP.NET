using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Service;

namespace RefugeeCamp.Web.Controllers
{
    public class TagController : Controller
    {
        GestionTag gtag=new GestionTag();
        // GET: Tag
        public ActionResult getTagsStartWith(string str)
        {
            return Json(gtag.GetTagsStartWith(str));
        }
    }
}