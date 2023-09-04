using System.Data;
using Microsoft.Data.SqlClient;

namespace Promocoes.Infrastructure.Shared.Factory
{
    public class SqlFactory
    {
        public static IDbConnection SqlFactoryConnection()
        {
            return new SqlConnection("Server=localhost;Database=promo_database;Uid=sa;Pwd=ramonramos;TrustServerCertificate=True;");
        }
    }
}