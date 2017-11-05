namespace RefugeeCamp.Data.Infrastructures
{
   public interface IDatabaseFactory
    {
        refugeescampContext Mycontext { get; }
       
    }
}
