using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RefugeeCamp.Data.Infrastructures;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service.utile;
using RefugeeCamp.Service.Utile;
using Service.Pattern;

namespace RefugeeCamp.Service
{
    public class GestionUser : Service<user>, IGestionUser
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);
        
        public GestionUser() : base(utw)
        {
        }



        public async Task<string> callLogin(string username, string password)
        {
            string token = null;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:18080/refugeesCamp-web/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Utilities.EncodeTo64(username + ":" + password));
                HttpResponseMessage response = await client.GetAsync("home/login").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    token = response.Headers.GetValues("Authorization").SingleOrDefault();

                }

            }
            return token;
        }


        public async Task callRegister(user u,string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/refugeesCamp-web/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (token != null)
                {
                    token = token.Substring(7);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Barear",token);
                }
                HttpResponseMessage response = await client.PostAsync("users",UserJsonSerializer.Serialize(u)).ConfigureAwait(false);
               
            }
        }

        public user GetUserByToken(string token)
        {
            token = token.Substring(7);
            string[] jwtStrings = token.Split('.');
            dynamic payload = JsonConvert.DeserializeObject<dynamic>(Base64Utilities.Decode64ToString(jwtStrings[1]));
            int i;

            Int32.TryParse(payload.id.ToString(), out i);
            return FindById(i);
        }

    }
}
