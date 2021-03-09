using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Entity.CustomEntity
{
    public class CustomApprovedPlugs
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OrderAsnNumber { get; set; }
        public string VendorDescription { get; set; }
        public string VehicleDesc { get; set; }
        public string WarehouseDescription { get; set; }
        public int TotalPackage { get; set; }
        public double TotalCHW { get; set; }

    }
}
