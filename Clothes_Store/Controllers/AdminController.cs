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


        [Route("Admin/Add")]
        public IActionResult AddClothes() { return View(); }

        [Route("Admin/Add")]
        [HttpPost]
        public async Task<IActionResult> AddClothes(ClothesPreview clothes)
        {
            var fileBytesImage = FunctionsLib.FileToByteArrayAsync(clothes.PreviwImageFileInput); //convert clothes img to byte array for db storing
            var seller = await GetSeller(clothes.SellerName);
            await ClothesRepository.CreateAsync(clothes.Name, fileBytesImage, clothes.TypeOfClothes,
               clothes.Color, seller.Id, clothes.Price, _context);
            return RedirectToAction("Index");
        }
        
        private async Task<Seller> GetSeller(string sellerName)
        {
            var seller = _context.Sellers.Where(x => x.Name == sellerName).FirstOrDefault();

            if (seller == null)  //create seller

            {
                var sellerNew = new Seller() { Name = sellerName };
                await _context.Sellers.AddAsync(sellerNew);
                await _context.SaveChangesAsync();
            }
            return seller;
        }

        public async Task<IActionResult> DeleteClothes(int id)
        {
            await ClothesRepository.DeleteAsync(id, _context);
            return RedirectToAction("Index");
        }
    }
}
