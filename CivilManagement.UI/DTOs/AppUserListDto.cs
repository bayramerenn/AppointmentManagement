namespace AppointmentManagement.UI.DTOs
{
    public class AppUserListDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string VendorDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsLocked { get; set; } = true;

        public string GetFullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}