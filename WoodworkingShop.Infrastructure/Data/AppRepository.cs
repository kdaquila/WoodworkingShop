using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.Infrastructure
{
    public class AppRepository<T> : IRepository<T> where T: BaseEntity
    {
        public AppDbContext _appDbContext { get; set; }
        public QueryOptionsEvaluator<T> _queryOptionsEvaluator { get; set; }

        public AppRepository(AppDbContext appDbContext, QueryOptionsEvaluator<T> queryOptionsEvaluator)
        {
            _appDbContext = appDbContext;
            _queryOptionsEvaluator = queryOptionsEvaluator;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Set<T>().FindAsync(new object[] { id });
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync(IQueryOptions<T> options)
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            query = _queryOptionsEvaluator.Evaluate(query, options);
            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<T> FirstOrDefaultAsync(IQueryOptions<T> options)
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            query = _queryOptionsEvaluator.Evaluate(query, options);
            return await query.FirstOrDefaultAsync();
        }
    }
}
