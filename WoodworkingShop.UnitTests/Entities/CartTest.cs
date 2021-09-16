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
        public void AddProductToCart()
        {
            Cart cart = new Cart();
            Guid productId = Guid.NewGuid();

            cart.AddProducts(productId: productId, quantity: 10);

            Assert.Equal(10, cart.CartItemSets.Find(c => c.ProductId == productId).Quantity);
        }

        [Fact]
        public void RemoveProductFromCart()
        {
            Cart cart = new Cart();
            Guid productId = Guid.NewGuid();

            cart.AddProducts(productId: productId, quantity: 10);
            cart.RemoveProducts(productId: productId, quantity: 5);

            Assert.Equal(5, cart.CartItemSets.Find(c => c.ProductId == productId).Quantity);
        }
    }
}
