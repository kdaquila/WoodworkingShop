using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Infrastructure;

namespace WoodworkingShop.IntegrationTests
{
    public class IntegrationTestFixture
    {
        public static async Task<AppDbContext> CreateDbContext()
        {
            var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            var appDbContext = new AppDbContext(dbOptions);

            await appDbContext.Products.AddAsync(new Product(new Guid(), "Band Saw", "Benchtop band saw", 400.0m));
            await appDbContext.SaveChangesAsync();

            return appDbContext;
        }
    }
}
