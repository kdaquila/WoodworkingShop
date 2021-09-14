using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Infrastructure;

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

            return query;
        }
    }
}
