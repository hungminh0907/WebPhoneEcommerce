using Microsoft.AspNetCore.Mvc;

namespace WebPhoneEcommerce.Areas.Admin.Controllers
{
    public class CRUDController : Controller
    {
        [Area("Admin")]
        [Route("/Danh-sach")]
        public IActionResult DanhSach()
        {
            return View();
        }

    }
}
