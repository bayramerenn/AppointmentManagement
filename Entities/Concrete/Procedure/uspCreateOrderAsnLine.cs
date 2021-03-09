using System;

namespace AppointmentManagement.Entities.Concrete.Procedure
{
    public class uspCreateOrderAsnLine
    {
        public string OrderAsnHeaderID { get; set; }

        public string ItemCode { get; set; }

        public string ColorCode { get; set; }

        public string ItemDim1Code { get; set; }

        public int Qty1 { get; set; }

        public byte ItemTypeCode { get; set; }

        public Guid OrderLineID { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}