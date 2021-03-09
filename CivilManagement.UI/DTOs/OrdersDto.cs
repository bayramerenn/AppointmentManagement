using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.DTOs
{
    public class OrdersDto
    {
        public string CurrAccCode { get; set; }
        public string OrderNumber { get; set; }
        public string CurrAccDescription { get; set; }
        public string WarehouseDescription { get; set; }
        public double Qty1 { get; set; }
        public double RemainingOrderQty1 { get; set; }
        public double SendQty { get; set; }
        public DateTime DeliveryDate { get; set; }

    }
}
