using RefugeeCamp.Domain.Models;
using Service.Pattern;
using System;
using RefugeeCamp.Data.Infrastructures;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeeCamp.Service
{
    public class GestionEvenement : Service<evenement>, IGestionEvenement
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);

        public GestionEvenement() : base(utw)
        {

        }

    }
}
