using System.Data;
using Dapper;
using Promocoes.Application.Input.Commands.BusinessContext;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Infrastructure.Input.Queries;
using Promocoes.Infrastructure.Shared.Factory;

namespace Promocoes.Infrastructure.Input.Repositories
{
    public class AuthenticationBusinessRepository : IAuthenticationBusinessRepository
    {
        private readonly IDbConnection _connection;

        public AuthenticationBusinessRepository()
        {
            _connection = SqlFactory.SqlFactoryConnection();
        }
        
        public AuthenticationCommand Authentication(AuthenticationCommand command)
        {
            var query = new BusinessQueries().AuthenticationQuery(command);

            try
            {
                using(_connection)
                {
                    return _connection.QueryFirstOrDefault<AuthenticationCommand>(query.Query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro interno: {ex.Message}");
            }
        }
    }
}