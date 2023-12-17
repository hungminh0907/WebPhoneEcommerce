using Microsoft.AspNetCore.Mvc;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebPhoneEcommerce.Models.Entity;
using WebPhoneEcommerce.Common;
using WebPhoneEcommerce.Models.Curd;
using Newtonsoft.Json;

namespace WebPhoneEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class HomeAdminController : Controller
    {

        private readonly PhoneEcommerceContext _context;
        private readonly IConfiguration _config;
        private readonly string _apiHost = "";
        public HomeAdminController(PhoneEcommerceContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _apiHost = config.GetValue<string>("UrlHost:ApiHost");
        }
        [Route("index")]
        public IActionResult Index()
        {
            return View();

        }



        [Route("DanhSach")]
        public async Task<IActionResult> DanhSach(string? timkiem)
        {
            //var items = _context.Products.Where(c => (c.Filter ?? "").Contains((timkiem ?? "").ToLower())).ToList();
            var Items = await getCurd();
            return View(Items);
        }

        public async Task<List<ViewModelCurd>>getCurd()
        {
            //string Url = "https://localhost:7007/api/ApiCurd/Show-danh-sach";
            string Url = _apiHost + @"api/ApiCurd/Show-danh-sach";

            using (var client = new HttpClient())
            {
                var res = await client.GetAsync(Url) ;

                if(res.IsSuccessStatusCode)
                {
                    var ViewlistItem = new List<ViewModelCurd>();

                    var ListItem = res.Content.ReadAsAsync<List<ResultApi>>().Result;
                    foreach (var item in ListItem)
                    {
                        ViewModelCurd ShowList = new ViewModelCurd();
                        ShowList.Id = item.Id;
                        ShowList.ProductId = item.ProductId;
                        ShowList.ProductName = item.ProductName;
                        ShowList.Description = item.Description;
                        ShowList.UnitPrice = item.UnitPrice;

                        ShowList.Urlimg = JsonConvert.DeserializeObject<List<ResultApiImg>>(item.Urlimg);


                        ViewlistItem.Add(ShowList);
                    }
                    return ViewlistItem;
                }
            }
            return null;
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
