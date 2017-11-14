using RefugeeCamp.Domain.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefugeeCamp.Data.Infrastructures;

namespace RefugeeCamp.Service
{
    public class GestionRefugees : Service<refugee>, IGestionRefugees
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);
        public GestionRefugees() : base(utw)
        {
        }
    }
}
