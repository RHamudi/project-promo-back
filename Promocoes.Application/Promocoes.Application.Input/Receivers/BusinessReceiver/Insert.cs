using MediatR;
using Promocoes.Application.Input.Commands.BusinessContext;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Receivers.BusinessReceiver
{
    public class Insert : IRequestHandler<BusinessCommand, State>
    {
        private readonly IWriteBusinessRepository _repository;

        public Insert(IWriteBusinessRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(BusinessCommand request, CancellationToken cancellationToken)
        {

            var business = new BusinessEntity(request.Name, request.Password, request.Description,
                request.Logo, request.Location, request.Contact, request.Category,
                request.Operation, request.GeoData, request.IsAdmin);

            if(!business.IsValid())
                return Task.FromResult(new State(400, "Erro ao inserir Empresa", business.Notifications));
            
            try 
            {
                _repository.InsertBusiness(business);
                return Task.FromResult(new State(200, "Empresa adicionada com sucesso", business));
            }
            catch(Exception ex)
            {
                return Task.FromResult(new State(500, ex.Message, null));
            }
        }
    }
}