using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Infrastructure;

namespace WoodworkingShop.IntegrationTests
{
    public class TestDbContextProvider
    {
        public static async Task<AppDbContext> createNewContext()
        {
            IConfiguration configuration = GetConfiguration();
            string connStr = configuration.GetConnectionString("WoodworkingShopTesting");

            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connStr)
                .Options); ;

            IRepository<Cart> carts = new AppRepository<Cart>(context, new QueryOptionsEvaluator<Cart>());
            ICartService cartService = new CartService(carts);
            var loggerFactory = new LoggerFactory();
            AppDbContextSeed seeder = new AppDbContextSeed();
            await seeder.Seed(context, loggerFactory, cartService);

            context.Database.BeginTransaction();

            return context;
        }

        public static IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }
    }
}
