using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;

namespace RefugeeCamp.Web.Controllers
{
    public class TaskController : Controller
    {
        private GestionTask gt = null;
        private GestionUser gu = null;

        public TaskController()
        {
            gt = new GestionTask();
            gu = new GestionUser();

        }
        // GET: Task
        public ActionResult Index()
        {
            return View(gt.QueryObjectGraph("User"));
        }
        public ActionResult IndexUser()
        {
            return View(gt.QueryObjectGraph("User"));
        }
        [HttpPost]
        public ActionResult IndexUser(string searchString)
        {
            var res = gt.QueryObjectGraph("User", t => t.name.Contains(searchString));
            return View(res);
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var res = gt.QueryObjectGraph("User", t => t.name.Contains(searchString));
            return View(res);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(gt.FindById(id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {

            var list = gu.FindByCondition();
            ViewBag.users = new SelectList(list, "id", "FullName");
            //        public string FullName { get { return firstName + " " + lastName; } }


            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(task t, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                t.UserId = Int32.Parse(collection["UserId"]);
                t.status = "started";//started,closed

                gt.Create(t);
                gt.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            task t = gt.FindById(id);

            var list = gu.FindByCondition();

            ViewBag.users = new SelectList(list, "id", "FullName");

            return View(gt.FindById(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            task t = null;

            t = gt.FindById(id);
            t.name = collection["name"];
            t.description = collection["description"];

            if (collection["startDate"] != null)
                t.startDate = DateTime.ParseExact(
                    collection["startDate"],
                    "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            if (collection["endDate"] != null)
                t.endDate = DateTime.ParseExact(
                collection["endDate"],
                "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            t.status = collection["status"];


            if (collection["user"] != null)
                t.UserId = Int32.Parse(collection["UserId"]);

            gt.Update(t);
            gt.Commit();
            return RedirectToAction("Index");

        }
        // GET: Task/Edit/5
        public ActionResult EditUser(int id)
        {
            task t = gt.FindById(id);

           

            return View(gt.FindById(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult EditUser(int id, FormCollection collection)
        {
            task t = null;

            t = gt.FindById(id);
            t.name = collection["name"];
            t.description = collection["description"];
            t.progress = Int32.Parse(collection["progress"]);

            gt.Update(t);
            gt.Commit();
            return RedirectToAction("IndexUser");

        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(gt.FindById(id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            gt.Remove(t => t.id == id);
            gt.Commit();
            return RedirectToAction("Index");

        }
    }
}
