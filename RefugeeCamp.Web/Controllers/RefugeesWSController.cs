using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using RefugeeCamp.Domain.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RefugeeCamp.Service;
namespace RefugeeCamp.Web.Controllers
{
    public class RefugeesWSController : Controller
    {
        private GestionMedicalFolder gms = null;
        public RefugeesWSController()
        {
            gms = new GestionMedicalFolder();
        }

        string Baseurl = "http://localhost:18080/";
        // GET: WebServiceConsume
        public async Task<ActionResult> Index()
        {
            List<refugee> refugees = new List<refugee>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource doList using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("refugeesCamp-web/api/Refugees");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var usersResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the users list  
                    refugees = JsonConvert.DeserializeObject<List<refugee>>(usersResponse);

                }
                //returning the employee list to view  
                return View(refugees);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,apparences,bloodpressure,bloodtype,description,doctorname,height,mentalstate,weight")]medicalfolder f)
        {   if (ModelState.IsValid)
            {
                int idR = ViewBag.id;
                gms.Create(f);
                return RedirectToAction("Index");
            }
            else return View(f);         
        }
    }
}