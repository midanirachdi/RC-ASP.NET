using System;
using System.Collections.Generic;
using RefugeeCamp.Domain.Models;
using Service.Pattern;

namespace RefugeeCamp.Service
{
   public interface IGestionTask:IService<task>
   {
       int GetTaskNbr();
   }
}
