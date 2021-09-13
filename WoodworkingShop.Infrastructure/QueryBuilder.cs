using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain.Interfaces;

namespace WoodworkingShop.Domain
{
    public class QueryBuilder<T>
    {
        public IQueryable<T> Build(IQueryable<T> query, IQueryOptions<T> options)
        {
            if (options.HasWhere())
            {
                query = query.Where(options.Where);
            }

            if (options.HasOrderBy())
            {
                query = query.OrderBy(options.OrderBy);
            }

            return query;
        }
    }
}
