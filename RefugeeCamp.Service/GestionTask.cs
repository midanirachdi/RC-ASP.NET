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

        //public IEnumerable<string> ListerTaskByUsername()
        //{
        //    //utw.GetRepository<task>().
        //    //    FindByCondition(x => x.UserId. == name).Where(x => x.DateProd.Year == 2008);

        //    //var tasklist =  utw.GetRepository<task>().FindByCondition();
        //    //var userlist = utw.GetRepository<user>().FindByCondition();

        //    //var TaskByUser = from task in tasklist
        //    //    from user in userlist
        //    //    where task.UserId == user.id
        //    //    select new {task, user.firstName};

        //    //return TaskByUser;

        //    //var res = from Table in ctx.Tables
        //    //from Reservation in ctx.Reservations
        //    //where Table.Id == Reservation.IdTable 
        //    //select Table;
        //}
    }
}
