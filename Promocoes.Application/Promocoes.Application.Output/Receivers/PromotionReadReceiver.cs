using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;

namespace Promocoes.Application.Output.Receivers
{
    public class PromotionReadReceiver : IRequestHandler<PromotionDTO, State>
    {
        private readonly IReadPromotionRepository _repository;

        public PromotionReadReceiver(IReadPromotionRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(PromotionDTO request, CancellationToken cancellationToken)
        {
            var getPromotions = _repository.GetAllPromotions();

            return Task.FromResult(new State(200, "Promoçoes coletadas com sucesso", getPromotions));
        }
    }
}