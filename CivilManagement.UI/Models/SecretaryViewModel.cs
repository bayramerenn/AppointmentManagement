using AppointmentManagement.UI.Identity;
using AppointmentManagement.UI.TagHelpers.TagHelperEntity;
using CivilManagement.UI.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Models
{
    public class SecretaryViewModel
    {
        public List<VehicleType> VehicleTypes { get; set; }
        public string UserId { get; internal set; }
        public IEnumerable<CustomSelectItem> OrderAsnHeadersList { get; set; }
        public IEnumerable<CustomSelectItem> ArticulatedLorry { get; set; }
        public IEnumerable<CustomSelectItem> Truck { get; set; }
        public IEnumerable<CustomSelectItem> Van { get; set; }
        public IEnumerable<CustomSelectItem> DeliveryVan { get; set; }
        public IEnumerable<CustomSelectItem> Car { get; set; }

    }
}
