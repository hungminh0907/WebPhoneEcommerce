using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebPhoneEcommerce.Models;
using WebPhoneEcommerce.Models.Entity;

namespace WebPhoneEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhoneEcommerceContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           // var items = _context.Products.Where(c => c.Filter.Contains((timkiem ?? "").ToLower())).ToList();
            var lstProduct = _context.Products.ToList();
            return View(lstProduct);
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