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
using System.Threading.Tasks;

namespace RefugeeCamp.Web.Controllers
{
    public class DonationController : Controller
    {
        private GestionCamp gc = null;
        public DonationController()
        {
            gc = new GestionCamp();
        }
        // GET: Donation/Create
        public ActionResult Create()
        {
            var list = gc.FindByCondition();
            ViewBag.camps = new SelectList(list, "id", "name");
            return View();
        }

        // POST: Donation/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            var client = new HttpClient();
            var url = "http://localhost:18080/refugeesCamp-web/api/donations/addtocamp";
            var parameters = new Dictionary<string, string> { { "amount", collection["amount"]}, { "currency",collection["currency"] } , { "camp_id", collection["CAMP_ID"] } };
            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = await client.PostAsync(url, encodedContent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Do something with response. Example get content:
                var responseContent = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
                return Redirect(responseContent);
            }
            return View();
        }
    }
}
