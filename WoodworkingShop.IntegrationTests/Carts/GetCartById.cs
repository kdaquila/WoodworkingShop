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
    public class GetCartById : BaseIntegrationTest
    {
        [Fact]
        public override async Task TestAsync()
        {
            CartService cartService = new CartService(
                new AppRepository<Cart>(_dbContext, 
                new QueryOptionsEvaluator<Cart>()));
            Guid cartId = Guid.NewGuid();
            await cartService.CreateNewCartAsync(cartId);

            Cart cart = _dbContext.Carts.FirstOrDefault(c => c.Id == cartId);

            Assert.NotNull(cart);
        }
    }
}
