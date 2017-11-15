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
    public class GestionDonation : Service<donation> , IGestionDonation
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);

        public GestionDonation() : base(utw)
        {

        }
    }
}
