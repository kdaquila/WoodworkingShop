using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public class CartService : ICartService
    {
        public IRepository<Cart> _carts { get; set; }

        public CartService(IRepository<Cart> carts)
        {
            _carts = carts;
        }

        public async Task AddProductsAsync(Guid cartId, Guid productId, int quantity)
        {
            IQueryOptions<Cart> options = new QueryOptions<Cart>();
            options.Where = c => c.Id == cartId;
            options.IncludeStrings.Add("CartItemSets");
            Cart cart = await _carts.FirstOrDefaultAsync(options);
            cart.AddProducts(productId, quantity);
            await _carts.UpdateAsync(cart);
        }

        public async Task RemoveProductsAsync(Guid cartId, Guid productId, int quantity)
        {
            IQueryOptions<Cart> options = new QueryOptions<Cart>();
            options.Where = c => c.Id == cartId;
            options.IncludeStrings.Add("CartItemSets");
            Cart cart = await _carts.FirstOrDefaultAsync(options);
            cart.RemoveProducts(productId, quantity);
            await _carts.UpdateAsync(cart);
        }

        public async Task CreateNewCartAsync(Guid cartId)
        {
            Cart cart = new Cart();
            cart.Id = cartId;
            await _carts.AddAsync(cart);
        }

        public async Task SetProductsAsync(Guid cartId, Guid productId, int quantity)
        {
            IQueryOptions<Cart> options = new QueryOptions<Cart>();
            options.Where = c => c.Id == cartId;
            options.IncludeStrings.Add("CartItemSets");
            Cart cart = await _carts.FirstOrDefaultAsync(options);
            cart.SetProducts(productId, quantity);
            await _carts.UpdateAsync(cart);
        }
    }
}
