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
        public PromotionsEntity(string idBusiness, string idProduct, DateTime startDate,
            DateTime endDate, double prevPrice, double discountedPrice)
        {
            IdPromotion = Guid.NewGuid().ToString();
            IdBusiness = idBusiness;
            IdProduct = idProduct;
            StartDate = startDate;
            EndDate = endDate;
            PrevPrice = prevPrice;
            DiscountedPrice = discountedPrice;
            CalculateDiscount();
        }

        public string IdPromotion { get; private set; }
        public string IdBusiness { get; private set; }
        public string IdProduct { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double PrevPrice { get; private set; }
        public double DiscountedPrice { get; private set; }
        public int Percentage { get; private set; }

        private void CalculateDiscount()
        {    
            this.Percentage = (int)((PrevPrice - DiscountedPrice) / PrevPrice * 100);
        }
        public bool IsValid()
        {
            return new PromotionsValidations(this).GuidIsValid()
                .GuidBusinessIsValid()
                .GuidProductIsValid()
                .IsValid();
        }
    }
}