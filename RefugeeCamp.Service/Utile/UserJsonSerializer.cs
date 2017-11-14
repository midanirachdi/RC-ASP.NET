using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RefugeeCamp.Domain.Models;
using RefugeeCamp.Service.JsonWrapper;

namespace RefugeeCamp.Service.Utile
{
    public class UserJsonSerializer
    {
        public static StringContent Serialize(user u)
        {
            string temp= JsonConvert.SerializeObject(UserWrapper.Wrap(u),
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            StringContent str = new StringContent(temp,Encoding.UTF8, "application/json");
            return str;
        }
    }
}
