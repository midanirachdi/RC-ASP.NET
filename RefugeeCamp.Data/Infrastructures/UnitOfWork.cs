namespace RefugeeCamp.Data.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseFactory dbfactory;
        private refugeescampContext ctx;
        public UnitOfWork(DatabaseFactory dbFactory)
        {
            this.dbfactory = dbFactory;
            ctx = dbfactory.Mycontext;

        }

        public UnitOfWork()
        {
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (ctx != null)
            {
                ctx.Dispose();
            }
        }
        public void commit()
        {
            ctx.SaveChanges();
        }

        public RespositoryBase<T> GetRepository<T>() where T : class
        {
            return new RespositoryBase<T>(dbfactory);
        }
    }
}
