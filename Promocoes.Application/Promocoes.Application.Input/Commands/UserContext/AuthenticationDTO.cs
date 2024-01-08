using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocoes.Application.Input.Commands.UserContext
{
    public class AuthenticationDTO
    {
         public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string VerificationToken { get; set; }
        public string VerifietAt { get; set; }
        public Guid? IdEmpresa { get; set; }
    }
}