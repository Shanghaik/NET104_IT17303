using Microsoft.AspNetCore.Mvc;
using Shopping_Application.IServices;
using Shopping_Application.Models;
using Shopping_Application.Services;
using System.Diagnostics;

namespace Shopping_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices productServices; // Interface
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productServices = new ProductServices(); // Class Service
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

        public IActionResult ShowListProduct()
        {
            List<Product> products = productServices.GetAllProducts();
            return View(products);
        }
        public IActionResult Create() // Khi ấn vào Create thì hiển thị View
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p) // Thực hiện việc Tạo mới
        {
            if (productServices.CreateProduct(p))
            {
                return RedirectToAction("ShowListProduct");
            }else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id) // Khi ấn vào Create thì hiển thị View
        {
            // Lấy Product từ database dựa theo id truyền vào từ route
            Product p = productServices.GetProductById(id);
            return View(p);
        }
       
        public IActionResult Edit(Product p) // Thực hiện việc Tạo mới
        {
            if (productServices.UpdateProduct(p))
            {
                return RedirectToAction("ShowListProduct");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (productServices.DeleteProduct(id))
            {           
                return RedirectToAction("ShowListProduct");
            }
            else return View("Index");
        }
        public IActionResult Details(Guid id)
        {
            ShopDbContext shopDbContext = new ShopDbContext();
            var product = shopDbContext.Products.Find(id);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}