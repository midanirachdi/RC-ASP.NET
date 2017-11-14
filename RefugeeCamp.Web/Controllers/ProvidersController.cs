using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RefugeeCamp.Web.Controllers
{
    public class ProvidersController : Controller
    {
        GestionProvider gProvider = null;
        public ProvidersController()
        {
            gProvider = new GestionProvider();
        }

        // GET: Providers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {/*
            IQueryable<provider> provList = gProvider.QueryObjectGraph("provider");
            List<SelectListItem> provNames = new List<SelectListItem>();
            foreach (var e in provList)
            {
                provNames.add(new SelectListItem { Text = e.nom, Value = e.nom });
            }
            var tuple = new Tuple<List<string>, commande>(provNames, new commande());
            return View(tuple);*/
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(provider prov)
        {
            if (ModelState.IsValid)
            {
                gProvider.Create(prov);
                gProvider.Commit();
                return RedirectToAction("Index");
            }
            else return View(prov);
        }


    }
}