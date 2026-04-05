using Microsoft.AspNetCore.Mvc;

namespace CuoiKy_CCMTPTPM.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessCheckout()
        {
            // For now, just redirect or handle with JS on client-side
            return Json(new { success = true });
        }
    }
}
