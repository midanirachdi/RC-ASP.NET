﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;
using RefugeeCamp.Web.Security;

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
            //ViewBag.usr =  SessionPersister.User.GetType();
            return View(gt.QueryObjectGraph("User"));
        }
        public ActionResult IndexUser()
        {
            String currentUsermail = SessionPersister.User.email;
            return View(gt.QueryObjectGraph("User",t=>t.user.email==currentUsermail));
        }
        [HttpPost]
        public ActionResult IndexUser(string searchString)
        {
            String currentUsermail = SessionPersister.User.email;
            var res = gt.QueryObjectGraph("User", t => t.name.Contains(searchString) && t.user.email == currentUsermail);
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
            HttpCookie cookie = Request.Cookies["ASP.NET_SessionId"];
            ViewBag.Mycookie = cookie.Value;


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
            HttpCookie cookie = Request.Cookies["ASP.NET_SessionId"];
            ViewBag.Mycookie = cookie.Value;
            task t = gt.FindById(id);

            var list = gu.FindByCondition();

            ViewBag.users = new SelectList(list, "id", "FullName");

            return View(gt.FindById(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            task t = gt.FindById(id);
            t.name = collection["name"];
            t.description = collection["description"];

            if(Request.Form["startDate"] != null)
            t.startDate = DateTime.Parse(Request.Form["startDate"]);

            if (Request.Form["endDate"] != null)
                t.endDate = DateTime.Parse(Request.Form["endDate"]);


            //t.endDate = DateTime.ParseExact(
            //    collection["endDate"],
            //    "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            t.status = collection["status"];


            
                t.UserId = Int32.Parse(collection["UserId"]);

            gt.Update(t);
            gt.Commit();
            return RedirectToAction("Index");

        }
        // GET: Task/Edit/5
        public ActionResult EditUser(int id)
        {
            HttpCookie cookie = Request.Cookies["ASP.NET_SessionId"];
            ViewBag.Mycookie = cookie.Value;
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
            HttpCookie cookie = Request.Cookies["ASP.NET_SessionId"];
            ViewBag.Mycookie = cookie.Value;
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
