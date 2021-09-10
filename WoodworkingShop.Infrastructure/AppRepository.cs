using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain.Entities;
using WoodworkingShop.Domain.Interfaces;

namespace WoodworkingShop.Infrastructure
{
    public class AppRepository<T> : IRepository<T> where T: BaseEntity
    {
        AppDbContext _appDbContext;

        public AppRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            await _appDbContext.Set<T>().FirstAsync(t => t.Id == id);
            return await _appDbContext.Set<T>().FindAsync(new object[] { id });
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public Task<IList<T>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
