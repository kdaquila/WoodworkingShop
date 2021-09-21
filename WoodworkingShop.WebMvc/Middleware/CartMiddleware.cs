using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.WebMvc
{
    public class CartMiddleware
    {
        private readonly RequestDelegate _next;

        public CartMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICartService cartService)
        {
            if (context.Session.GetString("CartId") == null)
            {
                Guid cartId = Guid.NewGuid();
                await cartService.CreateNewCartAsync(cartId);
                context.Session.SetString("CartId", cartId.ToString());
            }
 
            await _next(context);
        }
    }
}
