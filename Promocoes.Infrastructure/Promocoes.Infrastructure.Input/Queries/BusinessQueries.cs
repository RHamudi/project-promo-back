using Promocoes.Application.Input.Commands.BusinessContext;
using Promocoes.Domain.Entities;
using Promocoes.Infrastructure.Shared.Shared;

namespace Promocoes.Infrastructure.Input.Queries
{
    public class BusinessQueries : BaseQuery
    {
        public QueryModel InsertBusinessQuery(BusinessEntity entity)
        {
            Table = Map.GetTableBusiness();

            Query = $"""
                     
                                 INSERT INTO {Table}
                                 VALUES
                                 (
                                     @IdBusiness,
                                     @Name,
                                     @Description,
                                     @Logo,
                                     @Location,
                                     @Email,
                                     @Number,
                                     @Site,
                                     @Category,
                                     @Operation,
                                     @Geodata,
                                 )
                                 
                     """;

            Parameters = new {
                entity.IdBusiness,
                entity.Name,
                entity.Description,
                entity.Logo,
                entity.Location,
                entity.Contacts.Email,
                entity.Contacts.Number,
                entity.Contacts.Site,
                entity.Category,
                entity.Operation,
                Geodata = entity.GeoData,
            };

            return new QueryModel(Query, Parameters);
        }

        public QueryModel AuthenticationQuery(AuthenticationCommand command)
        {
            this.Table = Map.GetTableBusiness();

            this.Query = $@"

                            SELECT
                                tb.Email as  Email,
                                tb.Password as Senha
                            FROM
                            {this.Table} tb WHERE Email = '{command.Email}' AND Password = '{command.Password}'
                        
                          ";

            this.Parameters = new
            {
                Email = command.Email,
                Password = command.Password,
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}