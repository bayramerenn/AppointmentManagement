using System;
using System.ComponentModel.DataAnnotations;

namespace AppointmentManagement.Entities.Concrete
{
    public class trOrderAsnHeader
    {
        [Key]
        public Guid OrderAsnHeaderID { get; set; }

        public string OrderAsnNumber { get; set; }
        public DateTime OrderAsnDate { get; set; }

        public string ContainerTypeCode { get; set; }

        public int TotalPackage { get; set; }
        public double TotalCHW { get; set; }
        public string OfficeCode { get; set; }
        public string WarehouseCode { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsConfirmed { get; set; }
    }
}