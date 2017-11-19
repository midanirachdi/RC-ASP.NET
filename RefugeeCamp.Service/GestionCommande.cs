using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefugeeCamp.Domain.Models;
using Service.Pattern;
using RefugeeCamp.Data.Infrastructures;

namespace RefugeeCamp.Service
{
    public class GestionCommande :Service<commande>
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);
        public GestionCommande() : base(utw)
        {
        }
    }
}
