using WebPhoneEcommerce.Areas.Admin.Views.TaiKhoan;

namespace WebPhoneEcommerce.Areas.Admin.Models.TaiKhoan
{
    public class InputDangNhap
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Default";
        public string Token { get; set; }
    }
}
