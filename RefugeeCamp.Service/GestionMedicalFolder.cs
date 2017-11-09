using RefugeeCamp.Domain.Models;
using Service.Pattern;
using RefugeeCamp.Data.Infrastructures;

namespace RefugeeCamp.Service
{
    public class GestionMedicalFolder : Service<medicalfolder>, IGestionMedicalFolder
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(dbFactory);

        public GestionMedicalFolder() : base(utw)
        {
        }
        public medicalfolder findFolderById(int id)
        {
            medicalfolder f = utw.GetRepository<medicalfolder>().FindById(id);
            return f; 

        }
    }
}
