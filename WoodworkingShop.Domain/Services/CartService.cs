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
            Cart cart = await _carts.GetByIdAsync(cartId);
            cart.AddProducts(productId, quantity);
            await _carts.UpdateAsync(cart);
        }

        public async Task RemoveProductsAsync(Guid cartId, Guid productId, int quantity)
        {
            Cart cart = await _carts.GetByIdAsync(cartId);
            cart.RemoveProducts(productId, quantity);
        }

        public async Task CreateNewCartAsync(Guid cartId)
        {
            Cart cart = new Cart();
            cart.Id = cartId;
            await _carts.AddAsync(cart);
        }
    }
}
