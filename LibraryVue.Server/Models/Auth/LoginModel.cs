using System.ComponentModel.DataAnnotations;

namespace LibraryVue.Server.Models.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
