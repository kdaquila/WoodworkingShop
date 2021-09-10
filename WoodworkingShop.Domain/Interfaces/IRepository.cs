using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> ListAllAsync();
        Task<IList<T>> ListAsync();
        //Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        //Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        //Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        //Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        //Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        //Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    }
}
