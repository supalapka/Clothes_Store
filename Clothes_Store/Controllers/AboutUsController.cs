using Microsoft.AspNetCore.Mvc;

namespace Clothes_Store.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult about_us()
        {
            return View();
        }
    }
}
