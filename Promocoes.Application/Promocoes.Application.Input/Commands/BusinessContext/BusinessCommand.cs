using MediatR;
using Promocoes.Application.Input.Receivers;
using Promocoes.Domain.Enums;
using Promocoes.Domain.ValueObjects;

namespace Promocoes.Application.Input.Commands.BusinessContext
{
    public class BusinessCommand : IRequest<State>
    {
        public BusinessCommand(string name, string password, string description, string logo, string location, Contacts contact, ECategory category, string operation, string geoData, bool isAdmin)
        {
            Name = name;
            Password = password;
            Description = description;
            Logo = logo;
            Location = location;
            Contact = contact;
            Category = category;
            Operation = operation;
            GeoData = geoData;
            IsAdmin = isAdmin;
        }

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