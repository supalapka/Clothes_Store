using ClassLibrary;
using Clothes_Store.Models;
using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Store.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ClothesStoreDbContext _context;

        public AdminController(ClothesStoreDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var clothes = _context.Clothes.ToList();
            return View(clothes);
        }


        public IActionResult Statistics()
        {
            return View();
        }

        public async Task<IActionResult> DeleteClothes(int id)
        {
            await ClothesRepository.DeleteAsync(id, _context);
            return RedirectToAction("Index");
        }

        public IActionResult CreatePromocode()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromocode(Promocode promocode)
        {
            await _context.Promocodes.AddAsync(promocode);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
