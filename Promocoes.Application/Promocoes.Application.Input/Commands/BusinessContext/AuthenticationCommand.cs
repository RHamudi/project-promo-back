using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Input.Receivers;

namespace Promocoes.Application.Input.Commands.BusinessContext
{
    public class AuthenticationCommand : IRequest<State>
    {
        public AuthenticationCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Password { get; set; }
        public string Email { get; set; }
    }
}