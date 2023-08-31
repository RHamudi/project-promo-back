using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;
using Promocoes.Infrastructure.Shared.Shared;

namespace Promocoes.Infrastructure.Input.Queries
{
    public class BusinessQueries : BaseQuery
    {
        public QueryModel InsertBusinessQuery(BusinessEntity entity)
        {
            this.Table = Map.GetTableBusiness();

            this.Query = $@"
            INSERT INTO {this.Table}
            VALUES
            (
                @IdBusiness,
                @Name,
                @Password,
                @Description,
                @Logo,
                @Location,
                @Email,
                @Number,
                @Site,
                @Category,
                @Operation,
                @Geodata,
                @IsAdmin
            )
            ";

            this.Parameters = new {
                IdBusiness = entity.IdBusiness,
                Name = entity.Name,
                Password = entity.Password,
                Description = entity.Description,
                Logo = entity.Logo,
                Location = entity.Location,
                Email = entity.Contacts.Email,
                Number = entity.Contacts.Number,
                Site = entity.Contacts.Site,
                Category = entity.Category,
                Operation = entity.Operation,
                Geodata = entity.GeoData,
                IsAdmin = true ? 1 : 0
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}