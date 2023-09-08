using MediatR;
using Promocoes.Application.Input.Receivers;

namespace Promocoes.Application.Input.Commands.ProductContext
{
    public class ProductCommand : IRequest<State>
    {
        public ProductCommand(string idBusiness, string name, string description, string images, double price)
        {
            IdBusiness = idBusiness;
            Name = name;
            Description = description;
            Images = images;
            Price = price;
        }

        public string IdBusiness { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Images { get; private set; }
        public double Price { get; private set; }

    }
}