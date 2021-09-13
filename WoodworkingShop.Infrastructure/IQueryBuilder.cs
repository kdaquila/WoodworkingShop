using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Domain.Entities;

namespace WoodworkingShop.Infrastructure
{
    public interface IQueryBuilder<T> where T: BaseEntity
    {
        public IQueryable<T> Build(IQueryOptions<T> options);
    }
}
