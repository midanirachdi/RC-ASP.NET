﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefugeeCamp.Data.Infrastructures;
using RefugeeCamp.Domain.Models;
using Service.Pattern;

namespace RefugeeCamp.Service
{
    public class GestionTopic : Service<topic>
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);
        public GestionTopic() : base(utw)
        {
        }

        public List<topic> Search(string str)
        {

            List<string> words = str.ToUpper().Split(' ').ToList();

            List<topic> tpc = FindByCondition(e => e.title.Contains(str))
                .Union(FindByCondition(e => e.body.Contains(str))).ToList();
    
            

         
            return tpc;
        }
        public List<topic> getAllTopics()
        {
            return utw.GetRepository<topic>().MyContext.topics.Include("user").ToList();
        }


        public topic getByIdWithComments(int id)
        {
           
            topic t=utw.GetRepository<topic>().MyContext.topics.Include("comments").SingleOrDefault(x => x.id == id);
            return t;
        }
    }
}
