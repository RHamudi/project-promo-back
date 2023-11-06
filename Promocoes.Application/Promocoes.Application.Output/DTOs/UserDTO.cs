using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Promocoes.Application.Output.DTOs
{
    public class UserDTO : IRequest<State>
    {
        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string IdEmpresa { get; set; }
    }
}