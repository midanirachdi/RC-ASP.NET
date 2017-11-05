using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;

namespace RefugeeCamp.Web.Controllers
{
    public class JobOfferController : Controller
    {
        private GestionJobOffer gjo = null;

        public JobOfferController()
        {
                gjo = new GestionJobOffer();
            
        }
        // GET: JobOffer
        public ActionResult Index()
        {
            return View(gjo.GetMany());
        }

        // GET: JobOffer/Details/5
        public ActionResult Details(int id)
        {
            return View(gjo.FindById(id));
        }

        // GET: JobOffer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobOffer/Create
        [HttpPost]
        public ActionResult Create(joboffer jo)
        {
            gjo.Create(jo);
            gjo.Commit();
                return RedirectToAction("Index");
            
        }

        // GET: JobOffer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(gjo.FindById(id));
        }

        // POST: JobOffer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            joboffer jo = null;
            // TODO: Add update logic here
            jo = gjo.FindById(id);

            jo.contactName = collection["contactName"];
            gjo.Update(jo);
            gjo.Commit();
            return RedirectToAction("Index");
           
        }

        // GET: JobOffer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(gjo.FindById(id));
        }

        // POST: JobOffer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            gjo.Remove(jo => jo.id == id);
            gjo.Commit();
            return RedirectToAction("Index");
          
        }
    }
}
