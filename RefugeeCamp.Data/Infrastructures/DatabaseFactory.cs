namespace RefugeeCamp.Data.Infrastructures
{
    public class DatabaseFactory :Disposable, IDatabaseFactory
    {
        private refugeescampContext mycontext;
        public DatabaseFactory()
        {
            mycontext = new refugeescampContext();
        }
        public refugeescampContext Mycontext
        {
            get { return mycontext;}
        }
        protected override void DisposeCore()
        {
            if (Mycontext != null)
                Mycontext.Dispose();
        }
    }
}
