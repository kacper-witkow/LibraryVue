using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Shared.Model
{
    public class RegisterModel : IdentityUser
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public RegisterModel(string name, string password)
        {
            Name = name;
            Password = password;
        }
        public RegisterModel()
        {
        }
    }
}
