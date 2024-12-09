using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "mail is required")]
        [EmailAddress(ErrorMessage = "you must enter valid mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "minimum length is 5")]
        public string Password { get; set; }
    }
}
