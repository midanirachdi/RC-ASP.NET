using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefugeeCamp.Domain.Models;
using Service.Pattern;

namespace RefugeeCamp.Service
{
    interface IGestionMedicalFolder: IService<medicalfolder>
    {
        medicalfolder findFolderById(int id);
        
    }
}
