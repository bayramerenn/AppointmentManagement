using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.TagHelpers.TagHelperEntity
{
    public class CustomSelectItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public string Group { get; set; }
        public string VendorCode { get; set; }
        public string VehicleId { get; set; }
        public int TotalBox { get; set; }
        public double TotalPallet { get; set; }
    }
}
