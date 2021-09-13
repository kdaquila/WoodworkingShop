using System;
using System.Threading.Tasks;
using WoodworkingShop.Domain.Entities;
using WoodworkingShop.Domain.Interfaces;
using WoodworkingShop.Infrastructure;
using Xunit;

namespace WoodworkingShop.IntegrationTests.Products
{
    public class UpdateProduct : BaseIntegrationTest
    {
        [Fact]
        public override async Task TestAsync()
        {
            IRepository<Product> productRepo = new AppRepository<Product>(base._dbContext, new QueryBuilder<Product>());

            Product product = await productRepo.AddAsync(new Product(
                id: new Guid("a2d23a0e-aaa7-4d66-9c9e-08d974730ded"),
                name: "Band Saw",
                description: "Benchtop band saw",
                price: 400.0m));

            product.Name = "Large Band Saw";

            await productRepo.UpdateAsync(product);

            Product updatedProduct = await productRepo.GetByIdAsync(new Guid("a2d23a0e-aaa7-4d66-9c9e-08d974730ded"));

            Assert.Equal("Large Band Saw", updatedProduct.Name);
        }
    }
}
