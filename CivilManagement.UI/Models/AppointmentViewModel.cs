using System;

namespace AppointmentManagement.UI.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public string Description { get; internal set; }
        public string VendorCode { get; internal set; }
        public string ColorCode { get; set; }
    }
}