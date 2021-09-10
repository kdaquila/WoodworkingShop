using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain.Entities;
using WoodworkingShop.Domain.Interfaces;
using WoodworkingShop.Infrastructure;
using Xunit;

namespace WoodworkingShop.IntegrationTests
{
    public class GetProductById : BaseIntegrationTest
    {
        [Fact]
        public override async Task TestAsync()
        {
            await base._dbContext.Products.AddAsync(new Product(
                id: new Guid("a2d23a0e-aaa7-4d66-9c9e-08d974730ded"),
                name: "Band Saw",
                description: "Benchtop band saw",
                price: 400.0m));
            await base._dbContext.SaveChangesAsync();
            IRepository<Product> productRepo = new AppRepository<Product>(base._dbContext);

            Product product = await productRepo.GetByIdAsync(new Guid("a2d23a0e-aaa7-4d66-9c9e-08d974730ded"));

            Assert.NotNull(product);
        }
    }
}
