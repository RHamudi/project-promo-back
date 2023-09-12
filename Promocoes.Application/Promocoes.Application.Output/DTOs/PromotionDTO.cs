using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Promocoes.Application.Output.DTOs
{
    public class PromotionDTO : IRequest<State>
    {
        public Guid IdPromocao { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public Guid IdProduto { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataTermino { get; private set; }
        public double PrecoAnterior { get; private set; }
        public double PrecoDesconto { get; private set; }
        public int PorcentagemDesconto { get; private set; }
    }
}