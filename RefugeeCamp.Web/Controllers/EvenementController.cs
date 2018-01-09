using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Service;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Web.Security;

namespace RefugeeCamp.Web.Controllers
{
    public class EvenementController : Controller
    {
        private GestionEvenement ge = null;
        private GestionUser gu = null;
        public EvenementController()
        {
            ge = new GestionEvenement();
            gu = new GestionUser();
        }
        // GET: Evenement
        public ActionResult Index()
        {
            return View(ge.QueryObjectGraph("Campchef"));
        }
        [HttpPost]
        public ActionResult Index(string state)
        {
            if (state == "today")
                return View(ge.QueryObjectGraph("Campchef", t => t.dateEvent == DateTime.Today));
            if (state == "happened")
                return View(ge.QueryObjectGraph("Campchef", t => t.dateEvent < DateTime.Today));
            if (state == "to_come")
                return View(ge.QueryObjectGraph("Campchef", t => t.dateEvent > DateTime.Today));
            return View(ge.QueryObjectGraph("Campchef"));
        }
        // GET: Evenement/Details/5
        public ActionResult Details(int id)
        {
            return View(ge.FindById(id));
        }

        // GET: Evenement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evenement/Create
        [HttpPost]
        public ActionResult Create(evenement e,FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                e.creator_id = SessionPersister.User.id;
                e.name = collection["name"];
                e.dateEvent = DateTime.Now;
                e.location = collection["location"];
                e.nbplace = Convert.ToInt32(collection["nbplace"]);
                ge.Create(e);
                ge.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(int id)
        {
            evenement e = ge.FindById(id);
            var list = gu.FindByCondition(t => t is CampChef);

            ViewBag.users = new SelectList(list, "id", "FullName");
            return View(e);
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            evenement e = ge.FindById(id);
            e.name = collection["name"];
            e.dateEvent = Convert.ToDateTime(collection["dateEvent"]);
            e.location = collection["location"];
            e.nbplace = Convert.ToInt32(collection["nbplace"]);
            if (Request.Form["dateEvent"] != null)
                e.dateEvent = DateTime.Parse(Request.Form["dateEvent"]);

            e.creator_id = Int32.Parse(collection["creator_id"]);

            ge.Update(e);
            ge.Commit();
            return RedirectToAction("Index");
        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ge.FindById(id));
        }

        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ge.Remove(t => t.id == id);
            ge.Commit();
            return RedirectToAction("Index");
        }
    }
}
