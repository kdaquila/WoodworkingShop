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
        public static Guid sawCategoryId = new Guid("81654302-188e-4f1e-af1a-5d0d0d4eb2d1");
        public static Guid chiselCategoryId = new Guid("e3f84865-d817-4f52-b311-fa7e6283fd5c");
        public static Guid tableSawId = new Guid("e0a4f9ef-306f-4504-a9a5-131958600f5b");
        public static Guid mitreSawId = new Guid("5a91344f-f23b-4144-92b4-c360dbe362d4");
        public static Guid circularSawId = new Guid("2e581ab4-9ae1-4e8b-b87a-cf101e0d191b");
        public static Guid demoCartId = new Guid("fd8239b1-7dd1-40a0-ae08-ee290007a062");

        public static string sawCategoryName = "Saws";
        public static string chiselCategoryName = "Chisels";
        public static string tableSawName = "Table Saw";
        public static string mitreSawName = "Mitre Saw";
        public static string circularSawName = "Circular Saw";

        public async Task Seed(AppDbContext appDbContext, ILoggerFactory loggerFactory, ICartService cartService)
        {
            await SeedProductCategories(appDbContext);
            await SeedProducts(appDbContext);
            await SeedProductProductCategories(appDbContext);
            await SeedCart(appDbContext, cartService);

            ILogger logger = loggerFactory.CreateLogger<AppDbContextSeed>();
            logger.LogDebug("Database successfully seeded");
        }

        public async Task SeedProductCategories(AppDbContext appDbContext)
        {        
            if (!appDbContext.ProductCategories.Any(p => p.Name == sawCategoryName))
            {
                await appDbContext.ProductCategories.AddAsync(new ProductCategory(sawCategoryId, sawCategoryName));
            }                        
            
            if (!appDbContext.ProductCategories.Any(p => p.Name == chiselCategoryName))
            {
                await appDbContext.ProductCategories.AddAsync(new ProductCategory(chiselCategoryId, chiselCategoryName));
            }

            await appDbContext.SaveChangesAsync();
        }

        public async Task SeedProducts(AppDbContext appDbContext)
        {            
            if (!appDbContext.Products.Any(p => p.Name == tableSawName))
            {
                await appDbContext.Products.AddAsync(new Product(tableSawId, tableSawName, "A jobsite table saw", 300.0m));
            }
            
            if (!appDbContext.Products.Any(p => p.Name == mitreSawName))
            {
                await appDbContext.Products.AddAsync(new Product(mitreSawId, mitreSawName, "A jobsite mitre saw", 200.0m));
            }
            
            if (!appDbContext.Products.Any(p => p.Name == circularSawName))
            {
                await appDbContext.Products.AddAsync(new Product(circularSawId, circularSawName, "A jobsite circular saw", 100.0m));
            }

            await appDbContext.SaveChangesAsync();
        }

        public async Task SeedProductProductCategories(AppDbContext appDbContext)
        {

            if (!appDbContext.ProductProductCategories.Any(ppc => 
                ppc.ProductId == tableSawId && 
                ppc.ProductCategoryId == sawCategoryId))
            {
                await appDbContext.ProductProductCategories.AddAsync(new ProductProductCategory(tableSawId, sawCategoryId));
            }

            if (!appDbContext.ProductProductCategories.Any(ppc =>
                ppc.ProductId == mitreSawId &&
                ppc.ProductCategoryId == sawCategoryId))
            {
                await appDbContext.ProductProductCategories.AddAsync(new ProductProductCategory(mitreSawId, sawCategoryId));
            }

            if (!appDbContext.ProductProductCategories.Any(ppc =>
                ppc.ProductId == circularSawId &&
                ppc.ProductCategoryId == sawCategoryId))
            {
                await appDbContext.ProductProductCategories.AddAsync(new ProductProductCategory(circularSawId, sawCategoryId));
            }

            await appDbContext.SaveChangesAsync();
        }

        public async Task SeedCart(AppDbContext appDbContext, ICartService cartService)
        {
            if (!appDbContext.Carts.Any(c => c.Id == demoCartId))
            {
                await cartService.CreateNewCartAsync(demoCartId);
                await cartService.AddProductsAsync(demoCartId, tableSawId, 10);
                await cartService.AddProductsAsync(demoCartId, mitreSawId, 5);
            }

            await appDbContext.SaveChangesAsync();
        }
    }
}
