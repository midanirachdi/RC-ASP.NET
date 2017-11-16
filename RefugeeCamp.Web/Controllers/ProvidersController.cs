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
        IQueryable<provider> provList = null;
        GestionProvider gProvider = null;
        public ProvidersController()
        {
            gProvider = new GestionProvider();
            provList = gProvider.QueryObjectGraph("provider");
        }

        // GET: Providers
        public ActionResult Index()
        {
            /*List<provider> lp = new List<provider>();
            lp.Add(new provider { id=1,nom="fqsdqs",adresse="azaeaz",email="qsdsqfs@dsfsd.com",tel="14522"});
            lp.Add(new provider { id = 2, nom = "kldsfs", adresse = "lfdglfd", email = "kdfds@dsfsd.com", tel = "555" });*/
            var list = provList.Select(s => new { s.id, s.nom,s.email,s.adresse,s.tel }).ToList();
            List<provider> provs = new List<provider>();
            foreach (var e in list)
            {
                provs.Add(new provider { id=e.id,nom=e.nom,email=e.email,adresse=e.adresse,tel=e.tel});
            }
            return View(provs);
        }

        public ActionResult Create()
        {
           
            return View();
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
            

            

            var list = provList.Select(s => new { s.id, s.nom }).ToList();
            List<ListProvider> provNames = new List<ListProvider>();
            foreach (var e in list)
            {
                provNames.Add(new ListProvider { Id = e.id,Nom=e.nom });
            }

            return provNames;
        }


        public ActionResult Update(int id)
        {
            provider provCurrent = gProvider.findProviderById(id);
            return View(provCurrent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                provider prov = gProvider.findProviderById(id);
                prov.nom = collection["nom"];
                prov.email= collection["email"];
                prov.tel= collection["tel"];
                prov.adresse= collection["adresse"];
                gProvider.Update(prov);
                gProvider.Commit();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        
        public ActionResult Delete(int id)
        {
            provider p = gProvider.FindById(id);
            gProvider.remove(p);
            gProvider.Commit();
            return RedirectToAction("Index");
        }
    }
}