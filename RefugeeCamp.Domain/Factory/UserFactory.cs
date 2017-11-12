using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Domain.Factory
{
    public class UserFactory
    {
        public static user getInstance(string type)
        {
            switch (type)
            {
                case "Admin": return new Admin(); 
                case "DistrictChef": return new DistrictChef();
                case "CampChef": return  new CampChef();
                case "Volunteer": return  new Volunteer();

                default:
                    return null;
            }
        }
    }
}
