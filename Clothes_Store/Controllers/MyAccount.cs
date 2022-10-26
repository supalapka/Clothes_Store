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
            return RedirectToAction("Cart");
        }


        public IActionResult Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = _context.Carts.Where(x => x.ApplicationUserId == userId
            && x.IsOrderFinished == false).ToList();

            foreach (var cartItem in cart)
            {
                //fill the clothes class into current cart
                cartItem.Clothes = _context.Clothes.Where(x => x.Id == cartItem.ClothesId).FirstOrDefault(); 
            }
            return View(cart);
        }

        public IActionResult Orders()  //finished orders
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orders = _context.Carts.Where(x => x.ApplicationUserId == userId
            && x.IsOrderFinished == true).ToList();

            foreach (var order in orders)
            {
                //fill the clothes class into current order
                order.Clothes = _context.Clothes.Where(x => x.Id == order.ClothesId).FirstOrDefault();
            }

            return View(orders);
        }

        public IActionResult MyAds()
        {
            return View();
        }
    }
}
