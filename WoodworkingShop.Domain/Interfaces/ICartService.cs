using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public interface ICartService
    {
        public Task CreateNewCartAsync(Guid cartId);
        public Task AddProductsAsync(Guid cartId, Guid productId, int quantity);
        public Task RemoveProductsAsync(Guid cartId, Guid productId, int quantity);
    }
}
