using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.DTOs
{
    public class AppUserDto
    {
     

        [Required(ErrorMessage = "Lütfen Email adresini giriniz")]
        [Display(Name = "Email : ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon numarınızı giriniz")]
        [Display(Name = "Telefon : ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen tedarikçi kodunu giriniz")]
        [Display(Name = "Tedarikçi Kodu : ")]
        public string VendorCode { get; set; }

        [Required(ErrorMessage = "Lütfen tedarikçi adını giriniz")]
        [Display(Name = "Tedarikçi Adınız : ")]
        public string VendorDescription { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        [Display(Name = "İsim : ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen soyadını giriniz")]
        [Display(Name = "Soyadı : ")]
        public string LastName { get; set; }

        public bool IsLocked { get; set; } = true;
        public string Role { get; set; }

        [Required(ErrorMessage = "Lütfen parolayı giriniz")]
        [Display(Name = "Parola : ")]

        public string Password { get; set; }

        public string GetFullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}
