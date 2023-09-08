using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;
using Promocoes.Domain.Notifications;
using Promocoes.Domain.Validations.Interfaces;

namespace Promocoes.Domain.Validations
{
    public class PromotionsValidations : IValidate
    {
        private readonly PromotionsEntity _promotions;

        public PromotionsValidations(PromotionsEntity promotions)
        {
            this._promotions = promotions;
        }

        public PromotionsValidations GuidIsValid()
        {
            if(!Guid.TryParse(_promotions.IdPromotion, out Guid x))
                _promotions.AddNotification(new Notification("IdPromotion", "Id invalido"));

            return this;
        }
        public PromotionsValidations GuidProductIsValid()
        {
            if(!Guid.TryParse(_promotions.IdProduct, out Guid x))
                _promotions.AddNotification(new Notification("IdProduct", "Id invalido"));

            return this;
        }
        public PromotionsValidations GuidBusinessIsValid()
        {
            if(!Guid.TryParse(_promotions.IdBusiness, out Guid x))
                _promotions.AddNotification(new Notification("IdBusiness", "Id invalido"));

            return this;
        }

        public bool IsValid()
        {
            return _promotions.Notifications.Count == 0;
        }
    }
}