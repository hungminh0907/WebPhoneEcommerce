using Microsoft.AspNetCore.Mvc;

namespace WebPhoneEcommerce.Controllers
{
   
    public class CarditemController : Controller
    {
        [Route("card")]
        public IActionResult Card(string ProductId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }
    }
}
