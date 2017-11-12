using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RefugeeCamp.Web.ViewModels
{
    public class RegisterViewModel
    {
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IEnumerable<SelectListItem> TypeList
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = "Admin", Value = "Admin"},
                    new SelectListItem { Text = "CampChef", Value = "CampChef"},
                    new SelectListItem { Text = "DistrictChef", Value = "DistrictChef"},
                    new SelectListItem { Text = "Volunteer", Value = "Volunteer"}
                };
            }
        }
    }
}