using Microsoft.AspNetCore.Mvc;
using Common.Utilities;
using WebPhoneEcommerce.Models.Entity;
//using WebPhoneEcommerce.Common;

namespace WebPhoneEcommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly PhoneEcommerceContext _context;
        public ProductController(PhoneEcommerceContext context)
        {
            _context = context;
        }
        public IActionResult Index(string? timkiem)
        {
            var items = _context.Products.Where(c => c.Filter.Contains((timkiem ?? "").ToLower())).ToList();

            return View();
        }
        [Route("chi-tiet-san-pham")]
        public IActionResult Product()
        {
            return View();
        }
    }
}
