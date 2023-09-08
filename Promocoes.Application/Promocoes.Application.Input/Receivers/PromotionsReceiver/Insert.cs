using MediatR;
using Promocoes.Application.Input.Commands.PromotionsContext;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Receivers.PromotionsReceiver
{
    public class Insert : IRequestHandler<PromotionsCommand, State>
    {
        private readonly IWritePromotionsRepository _repository;

        public Insert(IWritePromotionsRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(PromotionsCommand request, CancellationToken cancellationToken)
        {   
            
            var promotion = new PromotionsEntity(request.IdBusiness, request.IdProduct, request.SartDate, request.EndDate, request.PrevPrice, request.DiscountedPrice);

            if(!promotion.IsValid())
                return Task.FromResult(new State(400, "Não foi possivel adicionar promoção", promotion.Notifications));

            try
            {
                _repository.InsertPromotions(promotion);
                return Task.FromResult(new State(200, "Promoção adicionada com sucesso", promotion));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}