using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Domain.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RefugeeCamp.Web.Controllers
{
   
    public class WebServiceConsumeController : Controller
    {
        string Baseurl = "http://localhost:18080/";
        // GET: WebServiceConsume
        public async Task<ActionResult> Index()
        {
            List<user> users = new List<user>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource doList using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("refugeesCamp-web/api/users");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var usersResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the users list  
                    users = JsonConvert.DeserializeObject<List<user>>(usersResponse);

                }
                //returning the employee list to view  
                return View(users);
            }
        }
    }
}