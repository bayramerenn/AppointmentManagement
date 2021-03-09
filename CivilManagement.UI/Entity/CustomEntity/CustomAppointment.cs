using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Entity.CustomEntity
{
    public class CustomAppointment
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OrderAsnNumber { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string VendorDescription { get; set; }
        public string VehicleDesc { get; set; }
        public int VehicleTypeId { get; set; }
        public Guid OrderAsnHeaderId { get; set; }
        public string UserId { get; set; }
        public string VendorCode { get; set; }

    }
}
