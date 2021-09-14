using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.Domain
{
    public interface IQueryOptionsEvaluator<T> where T: BaseEntity
    {
        public IQueryable<T> Evaluate(IQueryable<T> query, IQueryOptions<T> options);
    }
}
