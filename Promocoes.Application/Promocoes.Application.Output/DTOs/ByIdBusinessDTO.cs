using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Domain.ValueObjects;

namespace Promocoes.Application.Output.DTOs
{
    public class ByIdBusinessDTO : IRequest<State>
    {
        public ByIdBusinessDTO(string idEmpresa)
        {
            IdEmpresa = new Guid(idEmpresa);
        }

        public Guid IdEmpresa { get;  set; }
    }
}