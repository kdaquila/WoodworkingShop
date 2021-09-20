using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public interface IQueryOptions<T>
    {
        public List<String> IncludeStrings { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }

        public bool HasWhere();
        public bool HasOrderBy();
        public bool HasOrderByDescending();
        public bool HasIncludes();
    }
}
