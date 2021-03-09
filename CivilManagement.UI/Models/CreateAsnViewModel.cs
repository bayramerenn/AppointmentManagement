using AppointmentManagement.Entities.Concrete;
using AppointmentManagement.Entities.Concrete.Procedure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Models
{
    public class CreateAsnViewModel
    {
        public OrderWarehouse OrderWarehouse{ get; set; }
        public VehicleTypes VehicleTypes{ get; set; }
        public SelectList Vehicle{ get; set; }
        public SelectList OrderWarehouses { get; set; }
        public IEnumerable<uspGetOrderAsn> OrderAsn { get; internal set; }
    }
}
