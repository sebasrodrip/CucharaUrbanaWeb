using Frontend.Helpers.Implementations;
using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        IProductoHelper productoHelper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IProductoHelper _productoHelper,
            ILogger<HomeController> logger)
        {
            productoHelper = _productoHelper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductoViewModel> productos = productoHelper.GetAll();

            return View(productos);
            return View();
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