using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Identity
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string VehicleDesc { get; set; }
        public string Color { get; set; }
        public List<Appointment> Appointments{ get; set; }
    }
}
