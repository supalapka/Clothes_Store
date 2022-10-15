using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clothes_Store.Controllers
{
    public class CartController : Controller
    {

        private readonly ClothesStoreDbContext _context;

        public CartController(ClothesStoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = _context.Carts.Where(x => x.ApplicationUserId == userId
            && x.IsOrderFinished ==false).ToList();

            return View(cart);
        }  

        public async Task<IActionResult> AddToCart(int id)
        {
            var cart = new Cart()
            {
                ClothesId = id,
                ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier), // will give the userId
                Quantity = 1,
                IsOrderFinished = false,
                Size = Size.S,
            };
           await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return new EmptyResult();
        }

        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartItem = _context.Carts.Where(x=>x.ApplicationUserId == userId &&  x.ClothesId == id).FirstOrDefault();
            _context.Carts.Remove(cartItem);
            await _context.SaveChangesAsync();

            return new EmptyResult();
        }

    }
}
