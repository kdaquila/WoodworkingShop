using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Infrastructure;

namespace WoodworkingShop.IntegrationTests
{
    public abstract class BaseIntegrationTest : IDisposable
    {
        public AppDbContext _dbContext;
        public string _databaseName;

        public BaseIntegrationTest()
        {
            _databaseName = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                        .UseSqlServer($"Server=(localdb)\\mssqllocaldb;Integrated Security=true;Initial Catalog={_databaseName};")
                      .Options;

            _dbContext = new AppDbContext(options);
            _dbContext.Database.Migrate();
        }

        public abstract Task TestAsync();

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}
