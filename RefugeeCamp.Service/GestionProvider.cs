using RefugeeCamp.Data.Infrastructures;
using RefugeeCamp.Domain.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeeCamp.Service
{
    public class GestionProvider : Service<provider>
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);
        public GestionProvider() : base(utw)
        {
            
        }

        public IEnumerable<provider> getAllProviders()
        {
            return null;
        }

        public provider findProviderById(int id)
        {
            provider prov = utw.GetRepository<provider>().FindById(id);
            return prov;
        }
        public IEnumerable<provider> findAllProviders()
        {
            IEnumerable<provider> lp = utw.GetRepository<provider>().MyContext.providers;

            //IQueryable<provider> provList = utw.GetRepository<provider>().QueryObjectGraph("provider");
            return lp;
        }
    }
}
