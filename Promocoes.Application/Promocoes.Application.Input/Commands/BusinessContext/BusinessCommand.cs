using MediatR;
using Microsoft.AspNetCore.Http;
using Promocoes.Application.Input.Receivers;
using Promocoes.Domain.Enums;
using Promocoes.Domain.ValueObjects;

namespace Promocoes.Application.Input.Commands.BusinessContext
{
    public class BusinessCommand : IRequest<State>
    {
        public string IdUser { get; set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public IFormFile Logo { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Site { get; set; }
        public int Category { get; set; }
        public string Operation { get; set; }
        public string GeoData { get; set; }
    }
}