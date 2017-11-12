using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Service.JsonWrapper
{
    public class RootAdmin: IUserRoot
    {
        public Admin Admin { get; set; }
    }
}
