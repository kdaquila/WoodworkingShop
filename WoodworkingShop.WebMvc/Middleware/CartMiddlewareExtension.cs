using Microsoft.AspNetCore.Builder;

namespace WoodworkingShop.WebMvc
{
    public static class CartMiddlewareExtension
    {
        public static IApplicationBuilder UseCart(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CartMiddleware>();
        }
    }
}

