using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain.Entities;
using WoodworkingShop.Domain.Interfaces;
using WoodworkingShop.Infrastructure;
using Xunit;

namespace WoodworkingShop.IntegrationTests.Products
{
    public class ListAllProducts : BaseIntegrationTest
    {
        [Fact]
        public override async Task TestAsync()
        {
            await base._dbContext.Products.AddAsync(new Product(
                id: new Guid("a2d23a0e-aaa7-4d66-9c9e-08d974730ded"),
                name: "Band Saw",
                description: "Benchtop band saw",
                price: 400.0m));
            await base._dbContext.Products.AddAsync(new Product(
                id: new Guid("c67d1cee-0088-46e6-9c9f-08d974730ded"),
                name: "Hand Saw",
                description: "High quality hand saw",
                price: 100.0m));
            await base._dbContext.SaveChangesAsync();
            IRepository<Product> productRepo = new AppRepository<Product>(base._dbContext, new QueryBuilder<Product>());

            List<Product> products = await productRepo.ListAllAsync();

            Assert.Equal(2, products.Count);
        }
    }
}
