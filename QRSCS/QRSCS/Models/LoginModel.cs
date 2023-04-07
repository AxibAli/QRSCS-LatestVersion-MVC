using System.ComponentModel.DataAnnotations;

namespace QRSCS.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kindly Enter a User Name?")]
        public string UserName { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password Should Be Minimum Of 8 Character")]
        public string Password { get; set; }
    }
}