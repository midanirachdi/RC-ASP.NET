using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefugeeCamp.Data.Infrastructures;
using RefugeeCamp.Domain.Models;
using Service.Pattern;

namespace RefugeeCamp.Service
{
    public class GestionComment : Service<comment>
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);

        public GestionComment() : base(utw)
        {
        }



        public comment getCommentWithInclude(int id)
        {
            
            comment c = utw.GetRepository<comment>().MyContext.comments.Include("topic")
                .SingleOrDefault(cc => cc.id == id);
     
            return c;
        }


    }
}
