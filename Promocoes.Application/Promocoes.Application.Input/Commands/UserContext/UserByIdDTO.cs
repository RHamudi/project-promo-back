using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocoes.Application.Input.Commands.UserContext
{
    public class UserByIdDTO
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? IdBusiness { get; set; }
    }
}