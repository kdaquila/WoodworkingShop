using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.UnitTests.Mocks
{
    class MockRepository<T> : IRepository<T> where T: BaseEntity
    {
        List<T> _storage;
        MockQueryEvaluator<T> _queryEvaluator;

        public MockRepository()
        {
            _storage = new List<T>();
            _queryEvaluator = new MockQueryEvaluator<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await Task.Run(() => _storage.Add(entity));        
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _storage.Remove(entity));
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _storage.Find(o => o.Id == id ));
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
