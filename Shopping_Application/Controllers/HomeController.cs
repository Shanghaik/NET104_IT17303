using Microsoft.AspNetCore.Mvc;
using Shopping_Application.Models;
using System.Diagnostics;

namespace Shopping_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Redirect()
        {
            return RedirectToAction("Test"); // Thực hiện điều hướng đến 1 action nào đó
        }

        public IActionResult Show()
        {
            Product product = new Product() { 
                Id = Guid.NewGuid(),
                Name = "Hàng Tồn",
                Price = -10000, 
                AvailableQuantity = 1, 
                Supplier = "Bome", 
                Description = "Ko ai cần", 
                Status = 0 };
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}