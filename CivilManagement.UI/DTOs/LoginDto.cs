using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.DTOs
{
    public class LoginDto
    {
        [Display(Name = "Email adresiniz")]
        [Required(ErrorMessage = "Email alanı gereklidir")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Şifre alanı gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(1, ErrorMessage = "Şifreniz en az 4 karakterli olmalıdır...!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
