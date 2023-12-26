using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebPhoneEcommerce.Areas.Admin.Models.TaiKhoan;
using WebPhoneEcommerce.Areas.Admin.Views.TaiKhoan;
using NuGet.Common;

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

        [Route("dang-nhap")]
        [HttpPost]
        public async Task<IActionResult> DangNhap(InputDangNhap input)
        {
            //đăng nhập luôn khi đã có token trong cookie
            if (input.Token != "Default")
            {
                return await AccessLogin(input.Token);
            }            

            
            //string url = "http://localhost:5275/api/Authentication/auth";
            string url = _apiHost + @"api/Authentication/auth";
            if (ModelState.IsValid)
            {
                var data = new MultipartFormDataContent();
                data.Add(new StringContent(input.Email), "Email");
                data.Add(new StringContent(input.Username), "Username");
                data.Add(new StringContent(EncryptPassword(input.Password)), "Password");                
                data.Add(new StringContent(input.Role), "Role");

                var res = await _httpClient.PostAsync(url, data);

                if (res.IsSuccessStatusCode)
                {
                    var token = await res.Content.ReadAsAsync<OutputToken>();
                    return await AccessLogin(token.Token);
                }
            }

            return View();
        }
        private async Task<IActionResult> AccessLogin(string Token)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(Token) as JwtSecurityToken;
            var identity = new ClaimsIdentity(token.Claims, "Token");
            var principal = new ClaimsPrincipal(identity);

            var role = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var username = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            Response.Cookies.Append("Username", username);
            Response.Cookies.Append("Token", Token);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return await CheckRole(role);
        }
        private async Task<IActionResult> CheckRole(string? role)
        {
            if (role == "admin") return RedirectToAction("Index", "HomeAdmin", new { Areas = "Admin" });
            //if (role == "user") return RedirectToAction("Index", "Product", new { Areas = "" });//User
            if (role == "user") return RedirectToAction("Index", "Home", new { Areas = "" });//User
            //if (role == "nhansu") return RedirectToAction("Index", "Home", new { Areas = "NhanSu" });
            return Redirect("/");
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


        [Route("access-denied")]
        public IActionResult TuChoi()
        {
            return View();
        }


        [Route("logout")]
        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();
            Response.Cookies.Delete("Username");
            Response.Cookies.Delete("Token");
            return RedirectToAction("DangNhap", "TaiKhoan", new { Areas = "Admin" });
        }
    }
}
