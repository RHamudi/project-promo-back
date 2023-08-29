using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Validations;
using Promocoes.Domain.Validations.Interfaces;

namespace Promocoes.Domain.Entities
{
    public class PromotionsEntity : BaseEntity, IValidate
    {
        public PromotionsEntity(string idPromotion, string idBusiness, string idProduct, DateTime sartDate,
            DateTime endDate, double prevPrice, double discountedPrice)
        {
            IdPromotion = idPromotion;
            IdBusiness = idBusiness;
            IdProduct = idProduct;
            SartDate = sartDate;
            EndDate = endDate;
            PrevPrice = prevPrice;
            DiscountedPrice = discountedPrice;
            CalculateDiscount();
        }

        public string IdPromotion { get; private set; }
        public string IdBusiness { get; private set; }
        public string IdProduct { get; private set; }
        public DateTime SartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double PrevPrice { get; private set; }
        public double DiscountedPrice { get; private set; }
        public double Percentage { get; private set; }

        private void CalculateDiscount()
        {    
            this.Percentage = (PrevPrice - DiscountedPrice) / PrevPrice * 100;
        }
        public bool IsValid()
        {
            return new PromotionsValidations(this).GuidIsValid()
                .IsValid();
        }
    }
}