using Microsoft.AspNetCore.Mvc;

namespace Clothes_Store.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
