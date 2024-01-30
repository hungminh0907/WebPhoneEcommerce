using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebPhoneEcommerce.Models;
using WebPhoneEcommerce.Models.Curd;
using WebPhoneEcommerce.Models.Entity;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebPhoneEcommerce.Common;


namespace WebPhoneEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhoneEcommerceContext _context;

        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly string _apiHost = "";

        public HomeController(PhoneEcommerceContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _apiHost = config.GetValue<string>("UrlHost:ApiHost");
        }

        public async Task<IActionResult> Index()
        {
            var Items = await getCurd();
            return View(Items);
            //return View();
        }
        public async Task<List<ViewModelCurd>> getCurd()
        {
            //string Url = "https://localhost:7007/api/ApiCurd/Show-danh-sach";
            string Url = _apiHost + @"api/ApiCurd/Show-danh-sach";

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
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("details")]
        public async Task<IActionResult> Details(string ProductId)
        {
            var Items = await GetDetails(ProductId);
            return View(Items);
        }
        [HttpGet]
        public async Task<Product> GetDetails(string ProductId) 
        {
            //string Url = _apiHost + @"/Show-Product";
            string Url = Constrain.HostApi + Constrain.GetApi.Details;

            using (var client = new HttpClient())
            {
                var res = await client.GetAsync(Url);

                if (res.IsSuccessStatusCode)
                {
                    //if () {
                    //    var ViewlistItem = new List<ViewModelCurd>();
                    //}
                    

                  
                }
                
             }
            //return View();
        }

             
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}