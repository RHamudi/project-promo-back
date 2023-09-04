using MediatR;
using Promocoes.Domain.Enums;
using Promocoes.Domain.ValueObjects;

namespace Promocoes.Application.Output.DTOs
{
    public class BusinessDTO : IRequest<State>
    {
        public Guid IdEmpresa { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string LogoImagem { get; private set; }
        public string Localizacao { get; private set; }
        public Contacts Contatos { get; private set; }
        public ECategory Categoria { get; set; }
        public string HorarioOperacao { get; private set; }
        public string GeoLocalizacao { get; private set; }
        public bool Admin { get; private set; }
    }
}