using Microsoft.EntityFrameworkCore;
using System.Linq;
using WoodworkingShop.Domain;

namespace WoodworkingShop.Infrastructure
{
    public class QueryOptionsEvaluator<T> : IQueryOptionsEvaluator<T>  where T: BaseEntity
    {

        public IQueryable<T> Evaluate(IQueryable<T> query,  IQueryOptions<T> options)
        {
            if (options.HasWhere())
            {
                query = query.Where(options.Where);
            }

            if (options.HasOrderBy())
            {
                query = query.OrderBy(options.OrderBy);
            }

            if (options.HasOrderByDescending())
            {
                query = query.OrderByDescending(options.OrderByDescending);
            }

            if (options.HasIncludes())
            {
                foreach( string includeStr in options.IncludeStrings)
                {
                    query = query.Include(includeStr);
                }
            }

            return query;
        }
    }
}
