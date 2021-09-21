using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> FirstOrDefaultAsync(IQueryOptions<T> options);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(IQueryOptions<T> options);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        //Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        //Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    }
}
