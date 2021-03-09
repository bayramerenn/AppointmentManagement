using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AppointmentManagement.Entities.Concrete.Procedure
{
    public class uspGetOrderAsn
    {
        public Guid OrderAsnHeaderID { get; set; }
        public string OrderAsnNumber{ get; set; }
        public DateTime OrderAsnDate { get; set; }
        public int TotalPackage { get; set; }
        public double TotalCHW { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseDescription { get; set; }
        public string ContainerTypeDescription { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
