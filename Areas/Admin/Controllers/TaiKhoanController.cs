using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebPhoneEcommerce.Areas.Admin.Models.TaiKhoan;

namespace WebPhoneEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaiKhoanController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string _apiHost = "";
        public TaiKhoanController(IHttpClientFactory httpClient, IConfiguration config)
        {
            _httpClient = httpClient.CreateClient("Client");
            _config = config;
            _apiHost = config.GetValue<string>("UrlHost:ApiHost");
        }


        [Route("dang-nhap")]
        public IActionResult DangNhap()
        {
            return View();
        }




        [Route("dang-ky")]
        public IActionResult DangKy()
        {
            return View();
        }

        [Route("dang-ky")]
        [HttpPost]
        public async Task<IActionResult> DangKy(InputTaiKhoan input)
        {
            //string url = "http://localhost:5275/api/TaiKhoan/dang-ky";
            string url = _apiHost + @"api/TaiKhoan/dang-ky";

            if (ModelState.IsValid)
            {
                var data = new MultipartFormDataContent();
                data.Add(new StringContent(input.Email), "email");
                data.Add(new StringContent(input.Username), "username");
                data.Add(new StringContent(EncryptPassword(input.Password)), "password");
                data.Add(new StringContent(input.Role), "role");

                var res = await _httpClient.PostAsync(url, data);
                //var result = await res.Content.ReadAsAsync<OutputDangKy>();
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("DangNhap", "TaiKhoan", new { Areas = "Admin" });
                }
            }
            return View();
        }
        private string EncryptPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var data = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(data);
                return Convert.ToBase64String(hash);
            }
        }



    }
}
