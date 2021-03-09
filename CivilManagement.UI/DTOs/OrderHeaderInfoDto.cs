using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.DTOs
{
    public class OrderHeaderInfoDto
    {
        public Guid OrderAsnHeaderID { get; set; }
        public DateTime OrderAsnDate { get; set; }
        public string ContainerTypeCode { get; set; }
        public string WarehouseDescription { get; set; }
        public string ContainerTypeDescription { get; set; }
        public string OrderAsnNumber { get; set; }
        public string CurrAccCode { get; set; }
        public string CurrAccDescription { get; set; }
        public int TotalPackage { get; set; }
        public double TotalCHW { get; set; }
    }
}
