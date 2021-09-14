using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain.Entities;
using Xunit;

namespace WoodworkingShop.UnitTests
{
    public class CartTest
    {
        [Fact]
        public void AddProductToCart()
        {
            Cart cart = new Cart();
            Guid productId = new Guid();

            cart.AddCartItems(productId: productId, quantity: 10);

            Assert.Equal(10, cart.CartItemSets.Find(c => c.ProductId == productId).Quantity);
        }

        [Fact]
        public void RemoveProductFromCart()
        {
            Cart cart = new Cart();
            Guid productId = new Guid();

            cart.AddCartItems(productId: productId, quantity: 10);
            cart.RemoveCartItems(productId: productId, quantity: 5);

            Assert.Equal(5, cart.CartItemSets.Find(c => c.ProductId == productId).Quantity);
        }
    }
}
