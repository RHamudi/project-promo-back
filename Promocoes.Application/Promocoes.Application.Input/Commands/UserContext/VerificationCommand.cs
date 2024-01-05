using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Input.Receivers;

namespace Promocoes.Application.Input.Commands.UserContext
{
    public class VerificationCommand : IRequest<State>
    {
        public string Token { get; set; }
    }
}