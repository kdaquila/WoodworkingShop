using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Infrastructure;
using Xunit;

namespace WoodworkingShop.IntegrationTests.Products
{
    public class ProductCategoriesTest : TestDbContextProvider
    {
        [Fact]
        public async Task GetProductWithCategories()
        {
            using (var context = await createNewContext())
            {
                IRepository<Product> repo = new AppRepository<Product>(context, new QueryOptionsEvaluator<Product>());
                QueryOptions<Product> options = new QueryOptions<Product>();
                options.Where = (product) => product.Id == new Guid("e0a4f9ef-306f-4504-a9a5-131958600f5b");
                options.IncludeStrings.Add("ProductProductCategories.ProductCategory");
                Product product = await repo.FirstOrDefaultAsync(options);
                Assert.Equal("Saws", 
                    product
                    .ProductProductCategories
                    .FirstOrDefault(ppc => ppc.ProductCategory.Name == "Saws")
                    .ProductCategory.Name);
            }
        }
    }
}
