using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocoes.Application.Input.Commands.UserContext
{
    public class UserByIdDTO
    {
        public UserByIdDTO(string idUsuario, string nome, string email, string senha, string idEmpresa)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            IdEmpresa = idEmpresa;
        }

        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? IdEmpresa { get; set; }
    }
}