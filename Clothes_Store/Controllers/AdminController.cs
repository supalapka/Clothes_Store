using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }


        [Route("Admin/Add")]
        public IActionResult AddClothes() { return View(); }

        [Route("Admin/Add")]
        [HttpPost]
        public async Task<IActionResult> AddClothes(Clothes clothes)
        {

            return View();
        }
    }
}
