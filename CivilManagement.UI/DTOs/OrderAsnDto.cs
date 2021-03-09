using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.DTOs
{
    public class OrderAsnDto
    {
        public Guid OrderAsnHeaderID { get; set; }
        public string OrderAsnNumber { get; set; }
        public DateTime OrderAsnDate { get; set; }
        public double TotalPackage { get; set; }
        public double TotalCHW { get; set; }
        public string WarehouseDescription { get; set; }
        public string ContainerTypeDescription { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
