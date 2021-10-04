using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WoodworkingShop.WebMvc;

namespace WoodworkingShop.WebMvc
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductViewModelService _productViewModelService { get; }

        public ProductsController(
            ILogger<ProductsController> logger, 
            ProductViewModelService productViewModelService)
        {
            _logger = logger;
            _productViewModelService = productViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductViewModel> productViewModels = await _productViewModelService.getProductViewModels();
            return View(productViewModels);
        }
    }
}
