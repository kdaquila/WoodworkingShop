using System.Linq;
using System.Threading.Tasks;
using WoodworkingShop.Domain.Entities;
using WoodworkingShop.Infrastructure;
using Xunit;

namespace WoodworkingShop.IntegrationTests
{
    public class ReadProductTest
    {
        [Fact]
        public async Task ReadProduct()
        {
            AppDbContext appDbContext = await IntegrationTestFixture.CreateDbContext();

            Product product = appDbContext.Products.FirstOrDefault(p => p.Name == "Band Saw");

            Assert.NotNull(product);
        }


    }
}
