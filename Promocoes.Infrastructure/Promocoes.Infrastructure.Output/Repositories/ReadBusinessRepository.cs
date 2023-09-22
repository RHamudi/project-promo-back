using System.Data;
using Dapper;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;
using Promocoes.Domain.ValueObjects;
using Promocoes.Infrastructure.Output.Queries;
using Promocoes.Infrastructure.Shared.Factory;

namespace Promocoes.Infrastructure.Output.Repositories
{
    public class ReadBusinessRepository :  IReadBusinessRepository
    {
        private readonly IDbConnection _connection;

        public ReadBusinessRepository()
        {
            _connection = SqlFactory.SqlFactoryConnection();
        }

        public IEnumerable<AllBusinessDTO> GetAllBusiness()
        {
            var query = new BusinessQueries().GetAllBusinessQuery();

            try
            {
                using(_connection)
                {
                  return _connection.Query<AllBusinessDTO, Contacts, AllBusinessDTO>(query.Query, 
                  (business, contacts) => {
                    business.Contatos = contacts;
                    return business;
                  },
                  splitOn: "Email");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($@"Erro ao buscar empresas: {ex.Message}");
            }
        }

        public AllBusinessDTO GetBusinessById(Guid idEmpresa)
        {
            var query = new BusinessQueries().GetByIdBusinessQuery(idEmpresa);

            try
            {
                using(_connection)
                {
                    return _connection.Query<AllBusinessDTO, Contacts, AllBusinessDTO>(query.Query, 
                  (business, contacts) => {
                    business.Contatos = contacts;
                    return business;
                  },
                  splitOn: "Email").First();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($@"Erro ao buscar empresa: {ex.Message}");
            }
        }
    }
}