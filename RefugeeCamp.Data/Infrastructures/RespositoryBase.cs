using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RefugeeCamp.Data.Infrastructures
{
    public class RespositoryBase<T> : IRespositoryBase<T> where T : class
    {
        private refugeescampContext ctx;//not exposed
        public refugeescampContext MyContext { get { return ctx; } }
        private DbSet<T> dbset = null;
        public RespositoryBase(DatabaseFactory dbfactory)
        {
            ctx = dbfactory.Mycontext;
            dbset = ctx.Set<T>();
        }
        public void commit() { MyContext.SaveChanges(); }
        public void Create(T entity)
        {
            dbset.Add(entity);
        }

      /* public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orederby = null)
        {
            throw new NotImplementedException();
        }*/

        public T FindById(string id)
        {
            return dbset.Find(id);
        }

        public T FindById(int id)
        {
            return dbset.Find(id);
        }

        public void Remove(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> maListe = dbset.Where(condition);
            foreach (T item in maListe)
            {
                dbset.Remove(item);
            }
        }

        public void remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void Update(T entity)
        {
            //attacher lentite au dbset
            dbset.Attach(entity);
            //ecraser l'aancien objet par le nouveau
            MyContext.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> QueryObjectGraph(string children, Expression<Func<T, bool>> filter = null)
        {
            if (filter ==null)
            return dbset.Include(children);
            return dbset.Include(children).Where(filter);
        }
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition = null, 
                                              Expression<Func<T, bool>> orederby = null)
        {
            if (condition == null && orederby == null)
            {
                return dbset;
            }
            else
            if (condition != null && orederby == null)
            {
                return dbset.Where(condition);
            }
            else
            if (condition == null && orederby != null)
            {
                return dbset.OrderBy(orederby);
            }
            return dbset.Where(condition).OrderBy(orederby);
        }
       
    }
}
