﻿using ClassLibrary;
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
            var fileBytes = FunctionsLib.FileToByteArrayAsync(clothes.PreviwImageFileInput);
            var  seller = _context.Sellers.Where(x=>x.Name == clothes.SellerName).FirstOrDefault();
            if(seller == null)  //create seller
            {
                var sellerNew = new Seller()
                {
                    Name = clothes.SellerName
                };
                await _context.Sellers.AddAsync(sellerNew);
                await _context.SaveChangesAsync();
            }
            seller = _context.Sellers.Where(x => x.Name == clothes.SellerName).FirstOrDefault();
            await ClothesRepository.CreateAsync(clothes.Name, fileBytes, clothes.TypeOfClothes,
               clothes.Color, seller.Id, clothes.Price,_context);
            return RedirectToAction("Index");
        }
    }
}
