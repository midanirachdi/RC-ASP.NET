using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service;
using RefugeeCamp.Web.Models;
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

        [Route("/{type}")]
        public ActionResult Create(string type)
        {
            ProvidersController pvCtrl = new ProvidersController();

            ViewData["LoadProviders"] = DropDownList<ListProvider>.LoadItems(pvCtrl.getAllProviders(), "Id", "Nom");
            return View();

        }

        
            [HttpPost]
            [Route("/{type}")]
            
            public ActionResult Create(CommandeViewModel cmdVM, string type)
            {
                user currentUser = SessionPersister.User;
                var StockCtrl = new GestionStock();
            //stock currentStock =  StockCtrl.FindByCondition(p=>p.stockType.Equals(type)).First();
            commande cmd = new commande();//cmdVM.Commande;
            provider prv = new provider();
            GestionProvider gProvider = new GestionProvider();
            prv = gProvider.FindById(cmdVM.PostedProviderId);
            cmd.Admin1= (Admin)currentUser;
            //cmd.Admin1 =(Admin) currentUser;
            //cmd.stock1 = currentStock;
            //cmd.provider1 = prv;

            cmd.totalPrice=0;
            cmd.status=0;
                if (ModelState.IsValid)
                {
                    gCommandes.Create(cmd);
                    gCommandes.Commit();

                   
                    return RedirectToAction("Index");
                }
                else return View(cmd);
               
            }

    }
}