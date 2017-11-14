using System.Collections.Generic;
using System.Linq;
using RefugeeCamp.Data.Infrastructures;
using RefugeeCamp.Domain.Models;
using Service.Pattern;
using System;

namespace RefugeeCamp.Service
{
    public class GestionTask : Service<task>, IGestionTask
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);

        public GestionTask() : base(utw)
        {
        }
        
        public int GetTaskNbr()
        {
           return utw.GetRepository<task>().FindByCondition().Count();
        }
    }
}
