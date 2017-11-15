using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;
using RefugeeCamp.Web.Models;
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
        {
           
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

        public List<ListProvider> getAllProviders()
        {
            

            IQueryable<provider> provList = gProvider.QueryObjectGraph("provider");

            var list = provList.Select(s => new { s.id, s.nom }).ToList();
            List<ListProvider> provNames = new List<ListProvider>();
            foreach (var e in list)
            {
                provNames.Add(new ListProvider { Id = e.id,Nom=e.nom });
            }

            return provNames;
        }
    }
}