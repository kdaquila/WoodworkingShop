using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.UnitTests.Mocks
{
    public class MockQueryEvaluator<T> where T : BaseEntity
    {
        public IQueryable<T> Evaluate(IQueryable<T> list, IQueryOptions<T> options)
        {
            IQueryable<T> viewList = (new List<T>(list)).AsQueryable();

            if (options.HasWhere())
            {
                viewList = viewList.Where(options.Where);
            }

            if (options.HasOrderBy())
            {
                viewList = viewList.OrderBy(options.OrderBy);
            }

            if (options.HasOrderByDescending())
            {
                viewList = viewList.OrderByDescending(options.OrderByDescending);
            }

            return viewList;
        }
    }
}
