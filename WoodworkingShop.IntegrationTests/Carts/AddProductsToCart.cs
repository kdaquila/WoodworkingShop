using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Infrastructure;
using Xunit;

namespace WoodworkingShop.IntegrationTests.Carts
{
    public class AddProductsToCart : BaseIntegrationTest
    {
        [Fact]
        public override async Task TestAsync()
        {
            Guid mitreSawGuid = Guid.NewGuid();
            await _dbContext.Products.AddAsync(new Product(mitreSawGuid, "Mitre Saw", "A jobsite mitre saw", 200.0m));
            await _dbContext.SaveChangesAsync();
            CartService cartService = new CartService(
                new AppRepository<Cart>(_dbContext, 
                new QueryOptionsEvaluator<Cart>()));
            Guid cartId = Guid.NewGuid();
            await cartService.CreateNewCartAsync(cartId);
            int quantityAdded = 10;

            await cartService.AddProductsAsync(cartId, mitreSawGuid, quantityAdded);

            Cart cart = _dbContext.Carts.FirstOrDefault(c => c.Id == cartId);
            Assert.NotNull(cart.CartItemSets.FirstOrDefault(s => s.Quantity == quantityAdded));
        }
    }
}
