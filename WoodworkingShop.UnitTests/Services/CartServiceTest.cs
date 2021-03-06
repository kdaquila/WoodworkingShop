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

            Assert.NotNull(await mockRepository.GetByIdAsync(cartId));
        }

        [Fact]
        public async Task AddProductToCart()
        {
            IRepository<Cart> mockRepository = new MockRepository<Cart>();
            ICartService cartService = new CartService(mockRepository);
            Guid cartId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();
            int quantity = 10;
            await cartService.CreateNewCartAsync(cartId);

            await cartService.AddProductsAsync(cartId, productId, quantity);

            Cart storedCart = await mockRepository.GetByIdAsync(cartId);
            CartItemSet storedCartItemSet = storedCart.CartItemSets.Find(c => c.ProductId == productId);
            Assert.Equal(quantity, storedCartItemSet.Quantity);
        }

        [Fact]
        public async Task SetProductToCart()
        {
            IRepository<Cart> mockRepository = new MockRepository<Cart>();
            ICartService cartService = new CartService(mockRepository);
            Guid cartId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();
            int quantity = 10;
            await cartService.CreateNewCartAsync(cartId);

            await cartService.SetProductsAsync(cartId, productId, quantity);

            Cart storedCart = await mockRepository.GetByIdAsync(cartId);
            CartItemSet storedCartItemSet = storedCart.CartItemSets.Find(c => c.ProductId == productId);
            Assert.Equal(quantity, storedCartItemSet.Quantity);
        }

    }
}
