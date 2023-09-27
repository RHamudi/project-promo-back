using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Promocoes.Application.Output.DTOs
{
    public class ByIdProductDTO : IRequest<State>
    {
        public ByIdProductDTO(string idEmpresa)
        {
            IdEmpresa = new Guid(idEmpresa);
        }

        public Guid IdEmpresa { get;  set; }
    }
}