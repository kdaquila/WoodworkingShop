using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItemSet> CartItemSets { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductProductCategory> ProductProductCategories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<ProductProductCategory>()
                .HasKey(ppc => new { ppc.ProductId, ppc.ProductCategoryId });

            builder.Entity<ProductProductCategory>()
                .HasOne(ppc => ppc.Product)
                .WithMany(p => p.ProductProductCategories)
                .HasForeignKey(ppc => ppc.ProductId);

            builder.Entity<ProductProductCategory>()
                .HasOne(ppc => ppc.ProductCategory)
                .WithMany(pc => pc.ProductProductCategory)
                .HasForeignKey(ppc => ppc.ProductCategoryId);
        }
    }
}
