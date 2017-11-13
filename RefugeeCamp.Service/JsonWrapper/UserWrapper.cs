using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Service.JsonWrapper
{
    public class UserWrapper
    {
        public static IUserRoot Wrap(user u)
        {
            string tp = u.GetType().Name;
            switch (tp)
            {
                case "Admin":return new RootAdmin{ Admin = (Admin)u};
                case "CampChef": return new RootCampChef{CampChef =(CampChef)u};
                case "DistrictChef": return new RootDistrictChef{DistrictChef = (DistrictChef)u};
                case "Volunteer": return new RootVolunteer{Volunteer = (Volunteer)u};

                default: return null;
            }

        }
    }
}
