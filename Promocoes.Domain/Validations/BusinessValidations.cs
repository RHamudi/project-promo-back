using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;
using Promocoes.Domain.Notifications;
using Promocoes.Domain.Validations.Interfaces;

namespace Promocoes.Domain.Validations
{
    public class BusinessValidations : IValidate
    {
        private readonly BusinessEntity _business;

        public BusinessValidations(BusinessEntity business)
        {
            this._business = business;
        }

        public BusinessValidations GuidIsValid()
        {
            if(!Guid.TryParse(_business.IdBusiness, out Guid x))
                _business.AddNotification(new Notification("IdBusiness", "Id invalido"));

            return this;
        }

        public BusinessValidations NameLenght()
        {
            if(_business.Name.Length <= 3)
                _business.AddNotification(new Notification("Name", 
                    "Essa propriedade precisa conter no minimo 3 caracteres"));

            if(_business.Name.Length >= 100)
                _business.AddNotification(new Notification("Name",
                     "Essa propriedade não pode conter mais de 100 caracteres"));

            return this;
        }

        public BusinessValidations DescriptionLenght()
        {
            if(_business.Description.Length <= 10)
                _business.AddNotification(new Notification("Description", 
                    "Essa propriedade deve conter no minimo 10 caracteres"));

            if(_business.Description.Length >= 500)
                _business.AddNotification(new Notification("Description", 
                    "Essa propriedade não pode conter mais de 500 caracteres"));

            return this;
        }

        public BusinessValidations EmailIsValid()
        {
            if(!Regex.IsMatch(_business.Contact.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                _business.AddNotification(new Notification("Email", "Insira um email valido"));

            return this;
        }

        public BusinessValidations NumberIsValid()
        {
            if(!Regex.IsMatch(_business.Contact.Number, @"^\(\d{2}\) \d{4}-\d{4}$"))
                _business.AddNotification(new Notification("Number", "Insira um numero valido"));

            return this;
        }

        public bool IsValid()
        {
            return _business.Notifications.Count == 0;
        }
    }
}