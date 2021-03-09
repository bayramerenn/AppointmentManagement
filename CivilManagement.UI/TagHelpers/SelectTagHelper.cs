using AppointmentManagement.DataAccess.Abstract;
using AppointmentManagement.UI.TagHelpers.TagHelperEntity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.TagHelpers
{
    [HtmlTargetElement("optgroup", Attributes = "select-items")]
    public class SelectTagHelper : TagHelper
    {
     
        public IEnumerable<CustomSelectItem> SelectItems { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            string options = "";

            foreach (var item in SelectItems)
            {
                options += $"<option class='text-left' value='{item.Value}' data-vehicle='{item.VehicleId}' data-vendor='{item.VendorCode}' data-box='{item.TotalBox}' data-pallet='{item.TotalPallet}'>{item.Text}</opiton>";
            }


            output.Content.SetHtmlContent(options);

        }
    }
}
