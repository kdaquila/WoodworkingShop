using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Domain.Entities;
using WoodworkingShop.Domain.Interfaces;
using WoodworkingShop.Infrastructure;

namespace WoodworkingShop.Infrastructure
{
    public class QueryBuilder<T> : IQueryBuilder<T> where T: BaseEntity
    {
        public IQueryable<T> Build(DbContext dbContext,  IQueryOptions<T> options)
        {
            IQueryable<T> query = dbContext.Set<T>();

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
