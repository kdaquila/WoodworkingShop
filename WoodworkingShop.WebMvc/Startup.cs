using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WoodworkingShop.Domain;
using WoodworkingShop.Infrastructure;

namespace WoodworkingShop.WebMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ProductViewModelService>();
            services.AddScoped<CartViewModelService>();
            services.AddScoped(typeof(IQueryOptionsEvaluator<>), typeof(QueryOptionsEvaluator<>));
            services.AddScoped(typeof(ICartService), typeof(CartService));
            services.AddScoped(typeof(IRepository<>), typeof(AppRepository<>));

            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("WoodworkingShopData"));
            });

            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("WoodworkingShopIdentity"));
            });

            services.AddIdentity<AppIdentityUser, IdentityRole>(options => {
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseCart();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
