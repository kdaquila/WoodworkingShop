using Microsoft.EntityFrameworkCore;
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
        public async Task Seed(AppDbContext appDbContext, ILoggerFactory loggerFactory, ICartService cartService)
        {
            await SeedProducts(appDbContext);
            await SeedCart(appDbContext, cartService);

            ILogger logger = loggerFactory.CreateLogger<AppDbContextSeed>();
            logger.LogDebug("Database successfully seeded");
        }

        public async Task SeedProducts(AppDbContext appDbContext)
        {
            if (!appDbContext.Products.Any(p => p.Name == "Table Saw"))
            {
                await appDbContext.Products.AddAsync(new Product(Guid.NewGuid(), "Table Saw", "A jobsite table saw", 300.0m));
            }

            if (!appDbContext.Products.Any(p => p.Name == "Mitre Saw"))
            {
                await appDbContext.Products.AddAsync(new Product(Guid.NewGuid(), "Mitre Saw", "A jobsite mitre saw", 200.0m));
            }

            if (!appDbContext.Products.Any(p => p.Name == "Circular Saw"))
            {
                await appDbContext.Products.AddAsync(new Product(Guid.NewGuid(), "Circular Saw", "A jobsite circular saw", 100.0m));
            }

            await appDbContext.SaveChangesAsync();
        }

        public async Task SeedCart(AppDbContext appDbContext, ICartService cartService)
        {
            Guid demoCartId = new Guid("fd8239b1-7dd1-40a0-ae08-ee290007a062");
            if (!appDbContext.Carts.Any(c => c.Id == demoCartId))
            {
                await cartService.CreateNewCartAsync(demoCartId);
                Product tableSawProduct = await appDbContext.Products.FirstOrDefaultAsync(p => p.Name == "Table Saw");
                Product mitreSawProduct = await appDbContext.Products.FirstOrDefaultAsync(p => p.Name == "Mitre Saw");
                await cartService.AddProductsAsync(demoCartId, tableSawProduct.Id, 10);
                await cartService.AddProductsAsync(demoCartId, mitreSawProduct.Id, 5);
            }

            await appDbContext.SaveChangesAsync();
        }
    }
}
