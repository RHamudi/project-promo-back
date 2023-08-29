using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;
using Promocoes.Domain.Notifications;
using Promocoes.Domain.Validations.Interfaces;

namespace Promocoes.Domain.Validations
{
    public class ProductValidations : IValidate
    {
        private readonly ProductEntity _product;

        public ProductValidations(ProductEntity product)
        {
            this._product = product;
        }

        public ProductValidations GuidIsValid()
        {
            if(!Guid.TryParse(_product.IdProduct, out Guid x))
                _product.AddNotification(new Notification("IdProduct", "Id invalido"));

            return this;
        }

        public ProductValidations NameLength()
        {
            if(_product.Name.Length <= 3)
                _product.AddNotification(new Notification("Name", 
                    "Essa propriedade precisa conter no minimo 3 caracteres"));

            if(_product.Name.Length >= 100)
                _product.AddNotification(new Notification("Name",
                     "Essa propriedade não pode conter mais de 100 caracteres"));

            return this;
        }

        public ProductValidations DescriptionLength()
        {
            if(_product.Description.Length <= 10)
                _product.AddNotification(new Notification("Description", 
                    "Essa propriedade deve conter no minimo 10 caracteres"));

            if(_product.Description.Length >= 500)
                _product.AddNotification(new Notification("Description", 
                    "Essa propriedade não pode conter mais de 500 caracteres"));

            return this;
        }

        public bool IsValid()
        {
            return _product.Notifications.Count == 0;
        }
    }
}