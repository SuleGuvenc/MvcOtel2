using System.ComponentModel.DataAnnotations;

namespace Hotel.MVC.DTO
{
    public class RoleDTO
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "Enter Name!")]
        public string RoleName { get; set; }
    }
}
