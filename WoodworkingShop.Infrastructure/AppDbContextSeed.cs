using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.Infrastructure
{
    public class AppDbContextSeed
    {
        public static async Task Seed(AppDbContext appDbContext, ILoggerFactory loggerFactory)
        {
            if (!appDbContext.Products.Any(p => p.Name == "Table Saw"))
            {
                await appDbContext.Products.AddAsync(new Product(new Guid(), "Table Saw", "A jobsite table saw", 300.0m));
            }

            if (!appDbContext.Products.Any(p => p.Name == "Mitre Saw"))
            {
                await appDbContext.Products.AddAsync(new Product(new Guid(), "Mitre Saw", "A jobsite mitre saw", 200.0m));
            }

            if (!appDbContext.Products.Any(p => p.Name == "Circular Saw"))
            {
                await appDbContext.Products.AddAsync(new Product(new Guid(), "Circular Saw", "A jobsite circular saw", 100.0m));
            }

            await appDbContext.SaveChangesAsync();

            ILogger logger = loggerFactory.CreateLogger<AppDbContextSeed>();
            logger.LogDebug("Database successfully seeded");
        }
    }
}
