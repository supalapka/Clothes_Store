using DbAccessLibrary.DbAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Clothes_Store.Controllers
{
    public class MyAccount : Controller
    {

        private readonly ClothesStoreDbContext _context;

        public MyAccount(ClothesStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Cart() 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = _context.Carts.Where(x => x.ApplicationUserId == userId
            && x.IsOrderFinished == false).ToList();

            return View(cart);
        }

        public IActionResult Orders()  //finished orders
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orders = _context.Carts.Where(x => x.ApplicationUserId == userId
            && x.IsOrderFinished == true).ToList();

            return View(orders);
        }

        public IActionResult MyAds()
        {


            return View();
        }
    }
}
