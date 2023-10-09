using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
        
        public void Authentication(AuthenticationCommand command)
        {
            var query = new BusinessQueries().AuthenticationQuery(command);

            try
            {
                _connection.Execute(query.Query, query.Parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro interno: {ex.Message}");
            }
        }
    }
}