using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Models
{
    public class AddOrUpdateAppointmentModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int VehicleTypeId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Guid OrderAsnHeaderId { get; set; }
        public string Description { get; set; }
        public string VendorCode { get; set; }

    }
}
