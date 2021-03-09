using AppointmentManagement.Entities.Concrete;
using AppointmentManagement.UI.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivilManagement.UI.Entity
{
    public class AppUser:IdentityUser
    {
        public string VendorCode { get; set; }
        public string VendorDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLocked { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
