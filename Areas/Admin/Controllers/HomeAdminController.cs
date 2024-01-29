using Microsoft.AspNetCore.Mvc;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebPhoneEcommerce.Models.Entity;
using WebPhoneEcommerce.Common;
using WebPhoneEcommerce.Models.Curd;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace WebPhoneEcommerce.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin,Admin,ADMIN")]
    [Area("Admin")]
    [Route("/admin")]
    public class HomeAdminController : Controller
    {

        private readonly PhoneEcommerceContext _context;
        private readonly IConfiguration _config;
        private readonly string _apiHost = "";
        private string wwwroot;

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

        public async Task<List<ViewModelCurd>> getCurd()
        {
            //string Url = "https://localhost:70071/api/ApiCurd/Show-danh-sach";
           string Url = _apiHost + @"api/ApiCurd/Show-danh-sach1";

            using (var client = new HttpClient())
            {
                var res = await client.GetAsync(Url);

                if (res.IsSuccessStatusCode)
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
        

        [Route("them-khoa", Name = "them")]
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Them(Khoa input)
        public async Task<IActionResult> Them(InputCurdAD input)
        {
            string url = "http://localhost:7007/api/ApiCurd/them-san-pham";
            using (var client = new HttpClient())
            {
                var data = new MultipartFormDataContent();
                data.Add(new StringContent(input.ProductId), "ProductId");
                data.Add(new StringContent(input.ProductName), "ProductName");
                data.Add(new StringContent(input.Description), "Description");
                data.Add(new StringContent(input.UnitPrice), "UnitPrice");

                var listimg = new List<string>();
                foreach (var img in input.Images)
                {
                    var imgPath = UploadFiles.SaveImage(img);
                    listimg.Add(imgPath);
                    var imgStream = new MemoryStream(System.IO.File.ReadAllBytes(wwwroot + imgPath));
                    var imgContent = new ByteArrayContent(imgStream.ToArray());
                    data.Add(imgContent, "Images", img.FileName);
                }

                var res = await client.PostAsync(url, data);
                var resPut = await client.PutAsync(url, data);
                if (res.IsSuccessStatusCode)
                {
                    foreach (var path in listimg)
                    {
                        UploadFiles.RemoveImage(path);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    //co the them cac doan thong bao loi~
                    return View();
                }

            }
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
        public async Task<List<ViewModelCurd>> deleteSP(string id)
        {
            string Url = Constrain.HostApi + Constrain.DeletApi.Delete;
            using (var client = new HttpClient())
            {
                var res = await client.GetAsync(Url);

                if (res.IsSuccessStatusCode)
                { }
            } 
        }

                   
        
        //[Route("Them")]
        //[HttpPost]
        //public IActionResult addSP(string ProductId, string ProductName, string Description, decimal UnitPrice, IFormFile hinhanh)
        //{
        //    if (!string.IsNullOrEmpty(ProductId))
        //    {
        //        Product product = new Product();
        //        product.Id = Guid.NewGuid().ToString();
        //        product.ProductId = ProductId;
        //        product.ProductName = ProductName;
        //        product.Description = Description;
        //        product.UnitPrice = UnitPrice;
        //        product.Filter = ProductId + " " + ProductName.ToLower() + " " + Utility.ConvertToUnsign(Description.ToLower());
        //        product.Urlimg = UploadFiles.SaveImage(hinhanh);

        //        _context.Add(product);
        //        _context.SaveChanges();
        //        return RedirectToAction("DanhSach");
        //    }
        //    return View();
        //}

    }
}
