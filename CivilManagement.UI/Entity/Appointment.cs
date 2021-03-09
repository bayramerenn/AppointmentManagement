using AppointmentManagement.Entities.Concrete;
using CivilManagement.UI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Identity
{
    public class Appointment : ModelBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int VehicleTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid OrderAsnHeaderId { get; set; }
        public string Description { get; set; }
        public virtual AppUser User { get; set; }
        public VehicleType VehicleTypes { get; set; }
        public string VendorCode { get; set; }
    }
}
