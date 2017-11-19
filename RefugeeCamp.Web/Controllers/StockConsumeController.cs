using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Domain.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RefugeeCamp.Web.Controllers
{
    public class StockConsumeController : Controller
    {
        List<stock> stockList = new List<stock>();
       
       
        // GET: StockConsume
        string Baseurl = "http://localhost:18080/";
        // GET: WebServiceConsume
        public async Task<ActionResult> Index()
        {

            stockList = await this.getStockList();

            return View(stockList);

        }
        public async Task<List<stock>> getStockList()
        {
            List<stock> stockList = new List<stock>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource doList using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("refugeesCamp-web/api/stock");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var stockResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the users list  
                    stockList = JsonConvert.DeserializeObject<List<stock>>(stockResponse);

                }
                //returning the employee list to view  
                return stockList;
            }
        }

        public async Task<stock> ConsumeStockById(int id)
        {
            stock stockById = new stock();

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("refugeesCamp-web/api/stock/"+id);
                if (Res.IsSuccessStatusCode)
                {
                    var stockResponse = Res.Content.ReadAsStringAsync().Result;
                    stockById = JsonConvert.DeserializeObject<stock>(stockResponse);

                }
                return stockById;
            }
        }
    }
}