using Promocoes.Application.Input.Commands.Interfaces;

namespace Promocoes.Application.Input.Commands.PromotionsContext
{
    public class PromotionsCommand : ICommand
    {
        public string IdBusiness { get; private set; }
        public string IdProduct { get; private set; }
        public DateTime SartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double PrevPrice { get; private set; }
        public double DiscountedPrice { get; private set; }
        public double Percentage { get; private set; }
    }
}