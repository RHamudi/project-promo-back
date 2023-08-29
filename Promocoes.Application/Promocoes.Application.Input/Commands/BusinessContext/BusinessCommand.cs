using Promocoes.Application.Input.Commands.Interfaces;
using Promocoes.Domain.Enums;
using Promocoes.Domain.ValueObjects;

namespace Promocoes.Application.Input.Commands.BusinessContext
{
    public class BusinessCommand : ICommand
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Description { get; private set; }
        public string Logo { get; private set; }
        public string Location { get; private set; }
        public Contacts Contact { get; private set; }
        public ECategory Category { get; set; }
        public string Operation { get; private set; }
        public string GeoData { get; private set; }
        public bool IsAdmin { get; private set; }

    }
}