using System;

namespace RefugeeCamp.Data.Infrastructures
{
    public interface IUnitOfWork:IDisposable
    {
        RespositoryBase<T>GetRepository<T>()where T:class;
        void commit();
    }
}
