using Microsoft.AspNetCore.Mvc;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebPhoneEcommerce.Models.Entity;
using WebPhoneEcommerce.Common;

namespace WebPhoneEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class HomeAdminController : Controller
    {

        private readonly PhoneEcommerceContext _context;
        public HomeAdminController(PhoneEcommerceContext context)
        {
            _context = context;
        }
        [Route("index")]
        public IActionResult Index()
        {
            return View();

        }



        [Route("DanhSach")]
        public IActionResult DanhSach(string? timkiem)
        {
            var items = _context.Products.Where(c => (c.Filter ?? "").Contains((timkiem ?? "").ToLower())).ToList();
            return View(items);
        }

        
        [Route("Them")]
        public IActionResult addSP()
        {
            return View();
        }
        [Route("Them")]
        [HttpPost]
        public IActionResult addSP(string ProductId, string ProductName, string Description, decimal UnitPrice, IFormFile hinhanh)
        {
            if (!string.IsNullOrEmpty(ProductId))
            {
                Product product = new Product();
                product.Id = Guid.NewGuid().ToString();
                product.ProductId = ProductId;
                product.ProductName = ProductName;
                product.Description = Description;
                product.UnitPrice = UnitPrice;
                product.Filter = ProductId + " " + ProductName.ToLower() + " " + Utility.ConvertToUnsign(Description.ToLower());
                product.Urlimg = UploadFiles.SaveImage(hinhanh);

                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View();
        }
        [Route("Cap-Nhat")]
        public IActionResult updateSP(string id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(item);
        }
        [Route("Cap-Nhat")]
        [HttpPost]
        public IActionResult updateSP(string id, string ProductId, string ProductName, string Description, decimal UnitPrice, IFormFile hinhanh)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.ProductId = ProductId;
                item.ProductName = ProductName;
                item.Description = Description;
                item.UnitPrice = UnitPrice;
                item.Filter = ProductId + " " + ProductName.ToLower() + " " + Utility.ConvertToUnsign(Description.ToLower());
                item.Urlimg = UploadFiles.SaveImage(hinhanh);
                _context.Update(item);
                _context.SaveChanges();

            }
            return RedirectToAction("DanhSach");

        }


        [Route("Xoa")]
        public IActionResult deleteSP(string id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                bool check = UploadFiles.RemoveImage(item.Urlimg ?? "");

                if (check)
                {
                    _context.Remove(item);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Remove(item);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("DanhSach");
        }


    }
}
