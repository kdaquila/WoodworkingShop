using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodworkingShop.WebMvc.Controllers
{
    public class CartController : Controller
    {
        CartViewModelService _cartViewModelService { get; }

        public CartController(CartViewModelService cartViewModelService)
        {
            _cartViewModelService = cartViewModelService;
        }

        public async Task<IActionResult> Display(string id)
        {
            id = "fd8239b1-7dd1-40a0-ae08-ee290007a062";
            CartViewModel cartViewModel = await _cartViewModelService.GetCartViewModel(id);
            return View(cartViewModel);
        }
    }
}
