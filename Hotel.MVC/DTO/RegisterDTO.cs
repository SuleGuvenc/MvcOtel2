using System.ComponentModel.DataAnnotations;

namespace Hotel.MVC.DTO
{
    public class RegisterDTO
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Zorunlu")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sifre Zorunlu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sifre Zorunlu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girilen Sifreler birbiriniz tutumuyor")]
        public string RePassword { get; set; }
    }
}
