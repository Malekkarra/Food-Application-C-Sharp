using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public String? Email { get; set; }
        [Required]
        public String? Password { get; set; }

    }
}
