using System;
using System.Collections.Generic;
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
        
            return View(gt.FindByCondition());
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
            //        public string FullName { get { return firstName + " " + lastName; } }
            ViewBag.users = new SelectList(list,"id", "FullName");
           
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(task t,FormCollection collection)
        {
            t.UserId = Int32.Parse(collection["user"]);
            gt.Create(t);
            gt.Commit();
                return RedirectToAction("Index");
            
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(gt.FindById(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            task t = null;
            // TODO: Add update logic here
            t = gt.FindById(id);

            t.name = collection["name"];
            gt.Update(t);
            gt.Commit();
            return RedirectToAction("Index");
           
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
