using System;
using System.Collections.Generic;
using System.Text;


namespace AppointmentManagement.Entities.Concrete.Procedure
{
    public class uspGetVendorOrders
    {
        public string CurrAccCode { get; set; }
        public string OrderNumber { get; set; }
        public string CurrAccDescription { get; set; }
        public string WarehouseDescription { get; set; }
        public double Qty1 { get; set; }
        public double RemainingOrderQty1 { get; set; }
        public DateTime DeliveryDate { get; set; }
      
    }
}
