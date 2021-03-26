using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Empty Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Empty Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}