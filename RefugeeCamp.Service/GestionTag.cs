using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefugeeCamp.Data.Infrastructures;
using RefugeeCamp.Domain.Models;
using Service.Pattern;

namespace RefugeeCamp.Service
{
    public class GestionTag : Service<tag>
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);

        public GestionTag() : base(utw)
        {
        }

        public List<tag> GetTagsStartWith(string str)
        {
            return FindByCondition(t => t.name.StartsWith(str)).ToList();
        }
    }
}
