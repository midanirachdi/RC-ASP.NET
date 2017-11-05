using RefugeeCamp.Data.Infrastructures;
using RefugeeCamp.Domain.Models;
using Service.Pattern;

namespace RefugeeCamp.Service
{
    public class GestionJobOffer : Service<joboffer>, IGestionJobOffer
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);
        
        public GestionJobOffer() : base(utw)
        {
        }

        //public IEnumerable<joboffer> ListerProductByCategoryIn2008(string name)
        //{
        //    return utw.GetRepository<Product>().FindByCondition(x=>x.MyCategory.NameCategory==name).Where(x=>x.DateProd.Year==2008);
        //}
    }
}
