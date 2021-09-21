using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.WebMvc.Controllers
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

        public async Task<IActionResult> Display(string id)
        {
            id = "fd8239b1-7dd1-40a0-ae08-ee290007a062";
            CartViewModel cartViewModel = await _cartViewModelService.GetCartViewModel(id);
            return View(cartViewModel);
        }

        public async Task<IActionResult> AddProduct(string id)
        {
            Guid cartId = new Guid("fd8239b1-7dd1-40a0-ae08-ee290007a062");
            Guid tableSawId = new Guid("e0a4f9ef-306f-4504-a9a5-131958600f5b");
            int quantity = 10;
            await _cartService.AddProductsAsync(cartId, tableSawId, quantity);
            return RedirectToAction("Display");
        }
    }
}
