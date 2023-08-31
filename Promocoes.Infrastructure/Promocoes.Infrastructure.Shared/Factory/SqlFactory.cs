using System.Data;
using Microsoft.Data.SqlClient;

namespace Promocoes.Infrastructure.Shared.Factory
{
    public class SqlFactory
    {
        public static IDbConnection SqlFactoryConnection()
        {
            return new SqlConnection();
        }
    }
}