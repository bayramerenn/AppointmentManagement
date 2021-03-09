using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.DTOs
{
    public class AppUserEditDto
    {

        public string Id { get; set; }
        public string UserName { get; set; }

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

        [Display(Name = "Durum : ")]
        public bool IsLocked { get; set; } = true;

        
        [Display(Name = "Yeni Şifre : ")]
        [MinLength(4,ErrorMessage ="Şifreniz en az 4 rakamdan oluşmalıdır")]
        public string PasswordNew { get; set; }

        
        [Display(Name = "Tekrar Yeni Şifre : ")]
        [MinLength(4, ErrorMessage = "Şifreniz en az 4 rakamdan oluşmalıdır")]
        [Compare("PasswordNew",ErrorMessage = "Yeni şifre ve onay şifre farklıdır")]
        public string PasswordConfirm { get; set; }

     
    }
}
