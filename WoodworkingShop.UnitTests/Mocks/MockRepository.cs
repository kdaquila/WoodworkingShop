using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Infrastructure;

namespace WoodworkingShop.UnitTests
{
    class MockRepository<T> : IRepository<T> where T: BaseEntity
    {
        List<T> _storage;
        QueryOptionsEvaluator<T> _queryEvaluator;

        public MockRepository()
        {
            _storage = new List<T>();
            _queryEvaluator = new QueryOptionsEvaluator<T>();
        }

        public async Task AddAsync(T entity)
        {
            await Task.Run(() => _storage.Add(entity));   
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _storage.Remove(entity));
        }

        public async Task<T> FirstOrDefaultAsync(IQueryOptions<T> options)
        {
            return await Task.Run(() => _queryEvaluator.Evaluate(_storage.AsQueryable(), options).FirstOrDefault());
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            T result = await Task.Run(() => _storage.Find(o => o.Id == id));
            if (result == null)
            {
                throw new DbObjectNotFound($"Could not find the object with Id: {id}");
            }
            return result;
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await Task.Run(() => _storage);
        }

        public async Task<List<T>> ListAsync(IQueryOptions<T> options)
        {
            return await Task.Run(() => _queryEvaluator.Evaluate(_storage.AsQueryable(), options).ToList());
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _storage[_storage.FindIndex(o => o.Id == entity.Id)] = entity);
        }

    }
}
