using System;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Infrastructure;
using Xunit;

namespace WoodworkingShop.IntegrationTests.Products
{
    public class CRUDTest
    {
        [Fact]
        public async Task TestAsync()
        {
            using (var context = TestDbContextProvider.createNewContext())
            {
                // Setup
                IRepository<Product> productRepo = new AppRepository<Product>(context, new QueryOptionsEvaluator<Product>());
                Guid productId = new Guid("a2d23a0e-aaa7-4d66-9c9e-08d974730ded");
                string originalName = "Band Saw";
                string modifiedName = "Band Saw2";
                Product product = new Product(
                    id: productId,
                    name: originalName,
                    description: "Benchtop band saw",
                    price: 400.0m);

                // Create
                await productRepo.AddAsync(product);
                Product product1 = await productRepo.GetByIdAsync(productId);
                Assert.Equal(originalName, product1.Name);

                // Update
                product1.Name = modifiedName;
                await productRepo.UpdateAsync(product1);
                Product product2 = await productRepo.GetByIdAsync(productId);
                Assert.Equal(modifiedName, product2.Name);

                // Delete
                await productRepo.DeleteAsync(product2);
                await Assert.ThrowsAsync<DbObjectNotFound>(() => productRepo.GetByIdAsync(productId));
            }
        }
    }
}
