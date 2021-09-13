using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WoodworkingShop.WebMvc.Models;
using WoodworkingShop.WebMvc.ViewModels;

namespace WoodworkingShop.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ProductViewModelService _productViewModelService { get; }

        public HomeController(
            ILogger<HomeController> logger, 
            ProductViewModelService productViewModelService)
        {
            _logger = logger;
            _productViewModelService = productViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductViewModel> productViewModels = await _productViewModelService.buildViewModel();
            return View(productViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
