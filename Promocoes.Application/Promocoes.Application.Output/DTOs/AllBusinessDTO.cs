using MediatR;
using Promocoes.Domain.Enums;
using Promocoes.Domain.ValueObjects;

namespace Promocoes.Application.Output.DTOs
{
    public class AllBusinessDTO : IRequest<State>
    {
        public Guid IdEmpresa { get;  set; }
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public string LogoImagem { get;  set; }
        public string Localizacao { get;  set; }
        public string Categoria { get; set; }
        public string HorarioOperacao { get;  set; }
        public string GeoLocalizacao { get;  set; }
        public bool Admin { get;  set; }
        public Contacts Contatos { get; set; }
    }
}