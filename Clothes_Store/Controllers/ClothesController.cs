using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Clothes_Store.Controllers
{
    public class ClothesController :Controller
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
            return View();
        }

    }
}
