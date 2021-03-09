using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.Entities.Concrete.Procedure
{
    public class uspGetOrderAsnLineToOrderHeaderId
    {
        public Guid OrderAsnLineID { get; set; }
        public Guid OrderLineID { get; set; }
        public string OrderNumber { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string ColorCode { get; set; }
        public string ItemDim1Code { get; set; }
        public double Qty1 { get; set; }
        public double OrderAsnQty1 { get; set; }
        public double RemainingOrderQty1 { get; set; }
    }
}
