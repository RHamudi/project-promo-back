using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Validations;
using Promocoes.Domain.Validations.Interfaces;

namespace Promocoes.Domain.Entities
{
    public class ProductEntity : BaseEntity, IValidate
    {
        public ProductEntity(string idBusiness ,string name, string description, string images, double price)
        {
            IdProduct = Guid.NewGuid().ToString();
            IdBusiness = idBusiness;
            Name = name;
            Description = description;
            Images = images;
            Price = price;
        }

        public string IdProduct { get; private set; }
        public string IdBusiness { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Images { get; private set; }
        public double Price { get; private set; }

        public bool IsValid()
        {
            return new ProductValidations(this)
                .GuidIsValid()
                .NameLength()
                .DescriptionLength()
                .IsValid();
        }
    }
}