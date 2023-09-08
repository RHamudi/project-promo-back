using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Promocoes.Application.Output.DTOs
{
    public class ProductDTO : IRequest<State>
    {
        public Guid IdProduto { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Imagens { get; private set; }
        public double Preco { get; private set; }
    }
}