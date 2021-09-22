using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using Xunit;

namespace WoodworkingShop.UnitTests
{
    public class CartTest
    {
        [Fact]
        public void AddProductsToEmptyCart()
        {
            Cart cart = new Cart();
            Guid productId = Guid.NewGuid();
            int quantity = 10;

            cart.AddProducts(productId, quantity);

            Assert.Equal(quantity, cart.CartItemSets.Find(c => c.ProductId == productId).Quantity);
        }

        [Fact]
        public void AddProductsToPrefilledCart()
        {
            Cart cart = new Cart();
            Guid productId = Guid.NewGuid();
            int quantity1 = 5;
            int quantity2 = 10;
            cart.AddProducts(productId, quantity1);

            cart.AddProducts(productId, quantity2);

            Assert.Equal(quantity1 + quantity2, cart.CartItemSets.Find(c => c.ProductId == productId).Quantity);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddInvalidNumberOfProducts(int quantity)
        {
            Cart cart = new Cart();
            Guid productId = Guid.NewGuid();                 

            Assert.Throws<ArgumentException>(() => cart.AddProducts(productId, quantity));
        }

        [Fact]
        public void SetProductsToEmptyCart()
        {
            Cart cart = new Cart();
            Guid productId = Guid.NewGuid();
            int quantity = 10;

            cart.SetProducts(productId, quantity);

            Assert.Equal(quantity, cart.CartItemSets.Find(c => c.ProductId == productId).Quantity);
        }

        [Fact]
        public void SetProductsToPrefilledCart()
        {
            Cart cart = new Cart();
            Guid productId = Guid.NewGuid();
            int quantity1 = 5;
            int quantity2 = 10;
            cart.SetProducts(productId, quantity1);

            cart.SetProducts(productId, quantity2);

            Assert.Equal(quantity2, cart.CartItemSets.Find(c => c.ProductId == productId).Quantity);
        }

        [Fact]
        public void SetProductQuantityToZero()
        {
            Cart cart = new Cart();
            Guid productId = Guid.NewGuid();
            int quantity1 = 10;
            cart.SetProducts(productId, quantity1);
            int quantity2 = 0;

            cart.SetProducts(productId, quantity2);

            Assert.Null(cart.CartItemSets.Find(c => c.ProductId == productId));
        }

        [Theory]
        [InlineData(-1)]
        public void SetInvalidNumberOfProducts(int quantity)
        {
            Cart cart = new Cart();
            Guid productId = Guid.NewGuid();

            Assert.Throws<ArgumentException>(() => cart.SetProducts(productId, quantity));
        }

    }
}
