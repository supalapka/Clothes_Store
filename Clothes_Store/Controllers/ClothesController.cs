using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clothes_Store.Controllers
{
    [Authorize]
    public class ClothesController : Controller
    {
        private readonly ClothesStoreDbContext _context;

        public ClothesController(ClothesStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClothesDetails(int id)
        {
            var clothes = ClothesRepository.GetById(id,_context);
            return View(clothes);
        }

        public async Task<IActionResult> AddToCart(int id, int quantity, Size size)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await CartRepository.CreateAsync(id, quantity, size, userId, _context);
            return RedirectToAction("ClothesDetails", new { id });
        }

    }
}
