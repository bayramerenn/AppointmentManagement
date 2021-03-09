using AppointmentManagement.Entities.Concrete;
using AppointmentManagement.Entities.Concrete.Procedure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Models
{
    public class UpdateAsnViewModel
    {
        public string OrderAsnHeaderId { get; set; }
        public VehicleTypes VehicleTypes { get; set; }
        public SelectList Vehicle { get; set; }
        public int TotalPackage { get; set; }
        public int TotalCHW { get; set; }
        public IEnumerable<uspGetOrderAsnLineToOrderHeaderId> OrderAsnLine { get; internal set; }
        public IEnumerable<uspGetVendorOrderLine> VendorOrderLine { get; internal set; }
        public SelectList OrderWarehouses { get; internal set; }
        public OrderWarehouse OrderWarehouse { get; internal set; }
    }
}
