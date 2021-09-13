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
        AppDbContext _appDbContext;

        public QueryBuilder(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IQueryable<T> Build(IQueryOptions<T> options)
        {
            IQueryable<T> query = _appDbContext.Set<T>();

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
