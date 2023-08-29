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
        public ProductEntity( string name, string description, string images, double price,
            string duration)
        {
            IdProduct = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Images = images;
            Price = price;
            Duration = duration;
        }

        public string IdProduct { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Images { get; private set; }
        public double Price { get; private set; }
        public string Duration { get; private set; }


        public bool IsValid()
        {
            return new ProductValidations(this).GuidIsValid()
                .NameLength()
                .DescriptionLength()
                .IsValid();
        }
    }
}