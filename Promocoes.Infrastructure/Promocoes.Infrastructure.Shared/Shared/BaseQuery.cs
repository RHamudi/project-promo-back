using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocoes.Infrastructure.Shared.Shared
{
    public class BaseQuery
    {
        public string Table { get; set; }
        public string InnerTable { get; set; }
        public string Query { get; set; }
        public object Parameters { get; set; }
    }
}