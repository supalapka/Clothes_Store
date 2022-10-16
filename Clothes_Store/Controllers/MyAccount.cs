using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

            List<Clothes> clothes = new List<Clothes>();
            foreach (var cartItem in cart)
            {
                clothes.Add(_context.Clothes.Where(x => x.Id == cartItem.ClothesId).FirstOrDefault());
            }
            return View(clothes);
        }

        public IActionResult Orders()  //finished orders
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orders = _context.Carts.Where(x => x.ApplicationUserId == userId
            && x.IsOrderFinished == true).ToList();

            List<Clothes> clothes = new List<Clothes>();
            foreach (var order in orders)
            {
                clothes.Add(_context.Clothes.Where(x => x.Id == order.ClothesId).FirstOrDefault());
            }
            return View(clothes);
        }

        public IActionResult MyAds()
        {


            return View();
        }
    }
}
