using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.Domain
{
    public class QueryOptions<T> : IQueryOptions<T>
    {
        public List<string> IncludeStrings { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }

        public bool HasOrderBy() => OrderBy != null;
        public bool HasOrderByDescending() => OrderByDescending != null;
        public bool HasWhere() => Where != null;
        public bool HasIncludes() => IncludeStrings.Count > 0;

        public QueryOptions()
        {
            IncludeStrings = new List<String>();
        }
    }
}
