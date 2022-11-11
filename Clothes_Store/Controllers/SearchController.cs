using Microsoft.AspNetCore.Mvc;

namespace Clothes_Store.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Search()
        {
            return View();
        }
    }
}
