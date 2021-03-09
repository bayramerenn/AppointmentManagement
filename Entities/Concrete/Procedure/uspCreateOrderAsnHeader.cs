using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.Entities.Concrete.Procedure
{
    public class uspCreateOrderAsnHeader
    {
        public Guid OrderAsnHeaderID { get; set; }
        public string ContainerTypeCode { get; set; }
        public int BoxQuantity { get; set; }
        public int PalletQuantity { get; set; }
        public string VendorCode { get; set; }
        public string WarehouseCode { get; set; }
        public List<uspCreateOrderAsnLine> OrderAsnLines { get; set; }
    }
}
