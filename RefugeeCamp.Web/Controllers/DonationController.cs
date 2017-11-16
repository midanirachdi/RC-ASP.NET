using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Service;

namespace RefugeeCamp.Web.Controllers
{
    public class DonationController : Controller
    {
        private GestionDonation gd = null;

        public DonationController()
        {
            gd = new GestionDonation();
        }
        // GET: Donation/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Donation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            return View();
        }
    }
}
