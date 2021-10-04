using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.WebMvc
{
    public class CartController : Controller
    {
        CartViewModelService _cartViewModelService { get; }
        ICartService _cartService { get; }

        public CartController(CartViewModelService cartViewModelService, ICartService cartService)
        {
            _cartViewModelService = cartViewModelService;
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Guid cartId = new Guid(HttpContext.Session.GetString("CartId"));
            CartViewModel cartViewModel = await _cartViewModelService.GetCartViewModel(cartId);
            return View(cartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(
            [FromForm] Guid ProductId,
            [FromForm] int ProductQuantity)
        {
            Guid cartId = new Guid(HttpContext.Session.GetString("CartId"));
            await _cartService.AddProductsAsync(cartId, ProductId, ProductQuantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SetProduct(
            [FromForm] Guid ProductId,
            [FromForm] int ProductQuantity)
        {
            Guid cartId = new Guid(HttpContext.Session.GetString("CartId"));
            await _cartService.SetProductsAsync(cartId, ProductId, ProductQuantity);
            return RedirectToAction("Index");
        }
    }
}
