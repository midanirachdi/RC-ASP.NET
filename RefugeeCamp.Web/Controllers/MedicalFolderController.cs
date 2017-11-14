using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;
using System.Net;

namespace RefugeeCamp.Web.Controllers
{
    public class MedicalFolderController : Controller
    {
        private GestionMedicalFolder gm = null;
        private GestionRefugees gr = null;
        public MedicalFolderController()
        {
            gm = new GestionMedicalFolder();
            gr = new GestionRefugees();
        }

        // GET: MedicalFolder
        public ActionResult Index()
        {
            return View(gr.QueryObjectGraph("medicalfolder"));
        }

        public ActionResult Details(int id)
        {
            medicalfolder f = gm.FindById(id);
            return View(f);
        }

        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(medicalfolder f,int id)
        {
            
            if (ModelState.IsValid)
            {
                gm.Create(f);
                gm.Commit();
               
                refugee r = gr.FindById(id);
                r.fiche_ID = f.id;

                gr.Update(r);
                gr.Commit();
                return RedirectToAction("Index");
            }
            else return View(f);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            medicalfolder f = gm.FindById(id);
            refugee refu = gr.FindByCondition(r => r.medicalfolder.id == id).Single();
            refu.medicalfolder = null;
            refu.fiche_ID = null;

            gr.Update(refu);
            gm.remove(f);
            
            gr.Commit();
            gm.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            medicalfolder mfCurrent = gm.findFolderById(id);
            return View(mfCurrent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(medicalfolder f)
        {
                medicalfolder m = gm.findFolderById(f.id);
                gm.Update(m);
                gm.Commit();
                return RedirectToAction("Index");
         
        }
    }
}