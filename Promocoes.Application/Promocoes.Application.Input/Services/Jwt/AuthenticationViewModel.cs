using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promocoes.Application.Input.Services.Jwt
{
    public class AuthenticationViewModel
    {
        public AuthenticationViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Password { get; set; }
        public string Email { get; set; }
    }
}
