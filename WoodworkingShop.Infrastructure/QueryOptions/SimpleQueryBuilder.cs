using System;
using System.Linq;
using System.Linq.Expressions;
using WoodworkingShop.Domain;
using WoodworkingShop.Domain.Entities;

namespace WoodworkingShop.Infrastructure.QueryOptions
{
    public class SimpleQueryBuilder<T> : IQueryBuilder<T> where T : BaseEntity
    {
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }

        public IQueryable<T> _query { get; set; }

        public SimpleQueryBuilder(AppDbContext context)
        {
            _query = context.Set<T>();
        }

        public bool HasOrderBy() => OrderBy != null;

        public bool HasWhere() => Where != null;

        public IQueryable<T> Build()
        {
            if (HasWhere())
            {
                _query = _query.Where(Where);
            }

            if (HasOrderBy())
            {
                _query = _query.OrderBy(OrderBy);
            }

            return _query;
        }
    }
}
