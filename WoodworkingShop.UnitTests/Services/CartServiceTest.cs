using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using Xunit;

namespace WoodworkingShop.UnitTests
{
    public class CartServiceTest
    {
        [Fact]
        public async Task CreateNewCart()
        {
            IRepository<Cart> mockRepository = new MockRepository<Cart>();
            ICartService cartService = new CartService(mockRepository);
            Guid cartId = Guid.NewGuid();
            await cartService.CreateNewCartAsync(cartId);

            Cart storedCart = await mockRepository.GetByIdAsync(cartId);
            Assert.Equal(cartId, storedCart.Id);
        }

        [Fact]
        public async Task AddProductToCart()
        {
            IRepository<Cart> mockRepository = new MockRepository<Cart>();
            ICartService cartService = new CartService(mockRepository);
            Guid cartId = Guid.NewGuid();
            await cartService.CreateNewCartAsync(cartId);

            Guid productId = Guid.NewGuid();
            int quantity = 10;
            await cartService.AddProductsAsync(
                cartId: cartId, 
                productId: productId, 
                quantity: 10);

            Cart storedCart = await mockRepository.GetByIdAsync(cartId);
            CartItemSet storedCartItemSet = storedCart.CartItemSets.Find(c => c.ProductId == productId);
            Assert.Equal(quantity, storedCartItemSet.Quantity);
        }

        [Fact]
        public async Task RemoveProductToCart()
        {
            IRepository<Cart> mockRepository = new MockRepository<Cart>();
            ICartService cartService = new CartService(mockRepository);
            Guid cartId = Guid.NewGuid();
            await cartService.CreateNewCartAsync(cartId);

            Guid productId = Guid.NewGuid();
            int quantityAdded = 10;
            await cartService.AddProductsAsync(
                cartId: cartId,
                productId: productId,
                quantity: 10);
            int quantityRemoved = 5;
            await cartService.RemoveProductsAsync(
                cartId: cartId,
                productId: productId,
                quantity: 5);

            Cart storedCart = await mockRepository.GetByIdAsync(cartId);
            CartItemSet storedCartItemSet = storedCart.CartItemSets.Find(c => c.ProductId == productId);
            Assert.Equal(quantityAdded - quantityRemoved, storedCartItemSet.Quantity);
        }
    }
}
