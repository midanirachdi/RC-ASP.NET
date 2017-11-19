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
        IQueryable<commande> ordersList = null;
        //private GestionStock gStock = null;
        public CommandeController()
        {
            gCommandes = new GestionCommande();
            ordersList = gCommandes.QueryObjectGraph("commande");
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
            commande cmd = new commande();
            cmd.address = cmdVM.Commande.address;
            cmd.country = cmdVM.Commande.country;
            cmd.qteOfProduct = cmdVM.Commande.qteOfProduct;
            cmd.totalPrice = 0;
            cmd.status = 0;
            cmd.ordered = DateTime.Now;//.ToString("yyyy-MM-dd HH:mm:ss");
            cmd.Admin = currentUser.id;
            cmd.Provider = cmdVM.PostedProviderId;
            cmd.Stock = 1;

            /*//stock currentStock =  StockCtrl.FindByCondition(p=>p.stockType.Equals(type)).First();
            commande cmd = new commande();//cmdVM.Commande;
            provider prv = new provider();
            GestionProvider gProvider = new GestionProvider();
            prv = gProvider.FindById(cmdVM.PostedProviderId);
            cmd.Admin1= (Admin)currentUser;
            //cmd.Admin1 =(Admin) currentUser;
            //cmd.stock1 = currentStock;
            //cmd.provider1 = prv;

            cmd.totalPrice=0;
            cmd.status=0;*/
            if (ModelState.IsValid)
                {
                    gCommandes.Create(cmd);
                    gCommandes.Commit();
                    return RedirectToAction("Index");
                }
                else return View(cmd);
               
            }

        public ActionResult List()
        {
            return View(this.getOrdersViewModel());
            
        }
        
        public ActionResult ChangeStatusToShipped(int id)
        {
            commande cmd = gCommandes.FindById(id);
            cmd.status = 1;
            cmd.shipped = DateTime.Now;
            gCommandes.Update(cmd);
            gCommandes.Commit();
            return RedirectToAction("List");

        }

        public ActionResult Details(int id)
        {
            OrdersViewModel ordv = getOrdersViewModel().Find(e => e.Cmd.id == id);
            
            return View(ordv);
        }
        public ActionResult Update(int id)
        {
            commande cmdCurrent = gCommandes.FindById(id);
            return View(cmdCurrent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                commande prov = gCommandes.FindById(id);
                prov.address = collection["address"];
                prov.country = collection["country"];
                prov.qteOfProduct = int.Parse(collection["qteOfProduct"]);
                
                gCommandes.Update(prov);
                gCommandes.Commit();
                return RedirectToAction("List");
            }
            else
                return View();
        }

        public List<OrdersViewModel> getOrdersViewModel()
        {
            var list = ordersList.Select(s => new { s.id, s.address, s.country, s.ordered, s.qteOfProduct, s.shipped, s.status, s.totalPrice, s.Admin, s.Stock, s.Provider }).ToList();

            List<OrdersViewModel> orders = new List<OrdersViewModel>();
            foreach (var s in list)
            {
                //Console.WriteLine(s.Admin1.firstName);
                GestionUser gu = new GestionUser();
                GestionStock gs = new GestionStock();
                GestionProvider gp = new GestionProvider();

                commande cm = new commande { id = s.id, Admin = s.Admin, Stock = s.Stock, Provider = s.Provider, address = s.address, country = s.country, ordered = s.ordered, qteOfProduct = s.qteOfProduct, shipped = s.shipped, status = s.status, totalPrice = s.totalPrice };

                user a = gu.FindById(cm.Admin.GetValueOrDefault());
                stock st = gs.FindById(cm.Stock.GetValueOrDefault());
                provider p = gp.FindById(cm.Provider.GetValueOrDefault());
                orders.Add(new OrdersViewModel { Cmd = cm, AdminName = a.FullName, ProviderName = p.nom, StockType = st.stockType });
            }
            return orders;
        }

    }
}