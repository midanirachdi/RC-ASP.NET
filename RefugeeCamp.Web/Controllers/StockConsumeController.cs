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
using RefugeeCamp.Service;
using System.Net;
using System.IO;

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
                HttpResponseMessage Res = await client.GetAsync("http://localhost:18080/refugeesCamp-web/api/stock");

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

        public void UpdateStock(commande cmd)
        {

            GestionStock gs = new GestionStock();
            stock st = gs.FindById(cmd.Stock.GetValueOrDefault());
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:18080/refugeesCamp-web/api/stock");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "	{\"stockType\": \"" + st.stockType + "\",\"qteTotal\": " + cmd.qteOfProduct + ",\"qteInStock\": " + cmd.qteOfProduct + ",\"stockValue\": " + cmd.totalPrice + "}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
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