using System.ComponentModel.DataAnnotations;

namespace Hotel.MVC.DTO
{
    public class LoginDTO
    {
      [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        //-----------------------------------------------------------------------
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        //-----------------------------------------------------------------------
      
    }
}
