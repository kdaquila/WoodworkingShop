using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Domain.Entities;
using WoodworkingShop.Domain.Interfaces;

namespace WoodworkingShop.Infrastructure
{
    public class AppRepository<T> : IRepository<T> where T: BaseEntity
    {
        public AppDbContext _appDbContext { get; set; }
        public IQueryBuilder<T> _queryBuilder { get; set; }

        public AppRepository(AppDbContext appDbContext, IQueryBuilder<T> queryBuilder)
        {
            _appDbContext = appDbContext;
            _queryBuilder = queryBuilder;
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

        public async Task<IList<T>> ListAsync(IQueryOptions<T> options)
        {
            IQueryable<T> query = _queryBuilder.Build(options);
            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
