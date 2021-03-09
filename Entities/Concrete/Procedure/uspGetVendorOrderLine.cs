using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.Entities.Concrete.Procedure
{
    public class uspGetVendorOrderLine
    {
        public Guid OrderLineID { get; set; }
        public string OrderNumber { get; set; }
        public string WarehouseDescription { get; set; }
        public byte ItemTypeCode { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string ColorCode{ get; set; }
        public string ItemDim1Code { get; set; }
        public double Qty1 { get; set; }
        public double RemainingOrderQty1 { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
