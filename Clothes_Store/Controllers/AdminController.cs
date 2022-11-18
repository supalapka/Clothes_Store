using ClassLibrary;
using Clothes_Store.Data;
using Clothes_Store.Models;
using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Store.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ClothesStoreDbContext _context;
        private readonly ApplicationDbContext _appContext;

        public AdminController(ClothesStoreDbContext context, ApplicationDbContext appContext)
        {
            _appContext = appContext;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Statistics()
        {
            ApplicationValues valuesForStatistic = new ApplicationValues();
           
            // Замість x.id став новий стовпець CountSell
            List<Clothes> listClothes = _context.Clothes.OrderBy(x=>x.CountSell).ToList();
            int CountUser = _appContext.Users.Count();
            int Amount_money_spent =  _context.Carts.Where(x => x.IsOrderFinished == true).Sum(x=>x.Clothes.Price);
            int AveragePrice = Amount_money_spent / _context.Carts.Where(x => x.IsOrderFinished == true).Count();

            valuesForStatistic.clothes = listClothes;
            valuesForStatistic.CoutnUser = CountUser;
            valuesForStatistic.Amount_money_spent =  Amount_money_spent;
            valuesForStatistic.AveragePrice = AveragePrice;
            return View(valuesForStatistic);
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
