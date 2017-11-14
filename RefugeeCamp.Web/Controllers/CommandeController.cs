using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;
using RefugeeCamp.Web.Security;
using RefugeeCamp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RefugeeCamp.Web.Controllers
{
    public class CommandeController : Controller
    {
        private GestionCommande gCommandes = null;
        //private GestionStock gStock = null;
        public CommandeController()
        {
            gCommandes = new GestionCommande();
               
        }

        // GET: Commande
        public Task<ActionResult> Index()
        {
            
            var StockCtrl = new StockConsumeController();
            StockCtrl.ControllerContext = new ControllerContext(this.ControllerContext.RequestContext, StockCtrl);

            return StockCtrl.Index();
        }
        public ActionResult Create()
        {
            CommandeProviderModel cpm = new CommandeProviderModel();
            cpm.cvm = new CommandeViewModel();
            List<provider> pr = new List<provider>();
            pr.Add(new provider{ id = 1, nom = "salim" });
            pr.Add(new provider { id = 2, nom = "sdjkfkds" });

            cpm.cvm.ProviderList= new SelectList(pr, "DistrictName", "DistrictName");
            return View(cpm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(commande cmd, int id)
        {
            user currentUser = SessionPersister.User;
            var StockCtrl = new StockConsumeController();
            stock currentStock = await StockCtrl.ConsumeStockById(id);


            cmd.Admin1 =(Admin) currentUser;
            cmd.stock1 = currentStock;

            //stock st = gStock.FindById(id);
            /*
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
            else return View(f);*/
            return null;
        }
    }
}