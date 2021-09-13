using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public class SimpleQueryOptions<T> : IQueryOptions<T>
    {
        public Expression<Func<T, bool>> OrderBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Expression<Func<T, bool>> Where { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool HasOrderBy()
        {
            throw new NotImplementedException();
        }

        public bool HasWhere()
        {
            throw new NotImplementedException();
        }
    }
}
