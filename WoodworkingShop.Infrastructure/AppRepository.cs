using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Domain.Entities;
using WoodworkingShop.Domain.Interfaces;
using WoodworkingShop.Infrastructure.QueryOptions;

namespace WoodworkingShop.Infrastructure
{
    public class AppRepository<T> : IRepository<T> where T: BaseEntity
    {
        public AppDbContext _appDbContext { get; set; }

        public AppRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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

        public async Task<IList<T>> ListAsync(IQueryBuilder<T> queryBuilder)
        {
            IQueryable<T> query = queryBuilder.Build();
            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryBuilder<T> createQueryBuilder()
        {
            return new SimpleQueryBuilder<T>(_appDbContext);
        }
    }
}
