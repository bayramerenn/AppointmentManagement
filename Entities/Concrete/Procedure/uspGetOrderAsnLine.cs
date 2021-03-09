namespace AppointmentManagement.Entities.Concrete.Procedure
{
    public class uspGetOrderAsnLine
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string ColorCode { get; set; }
        public string ItemDim1Code { get; set; }
        public double Qty1 { get; set; }
    }
}