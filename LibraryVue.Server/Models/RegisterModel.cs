using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Shared.Model
{
    public class RegisterModel : IdentityUser
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public RegisterModel(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
