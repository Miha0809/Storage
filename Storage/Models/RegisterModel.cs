using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Empty Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Empty FirstName")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Confirmation error")]
        public string ConfirmPassword { get; set; }

    }
}