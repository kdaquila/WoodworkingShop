using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public class QueryOptions<T> : IQueryOptions<T>
    {
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }

        public bool HasOrderBy() => OrderBy != null;
        public bool HasOrderByDescending() => OrderByDescending != null;
        public bool HasWhere() => Where != null;
    }
}
