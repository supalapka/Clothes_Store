﻿using ClassLibrary;
using Clothes_Store.Models;
using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        public IActionResult Details(int id)
        {
            var clothes = ClothesRepository.GetById(id,_context);
            return View(clothes);
        }

        public async Task<IActionResult> AddToCart(int id, int quantity, Size size)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await CartRepository.CreateAsync(id, quantity, size, userId, _context);
            return RedirectToAction("Details", new { id });
        }

        public IActionResult List()
        {
            return View();
        }


        [Route("Clothes/ad")]
        public IActionResult CreateAd() { return View(); }


        [Route("Clothes/ad")]
        [HttpPost]
        public async Task<IActionResult> CreateAd(ClothesPreview clothes)
        {
            var fileBytesImage = FunctionsLib.FileToByteArrayAsync(clothes.PreviwImageFileInput); //convert clothes img to byte array for db storing
            string sellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int id = await ClothesRepository.CreateAndReturnIdAsync(name: clothes.Name,
                previewImage: fileBytesImage,
                clothingCategory: clothes.Category,
                gender: clothes.Gender,
                color: clothes.Color,
                sellerId: sellerId,
                price: clothes.Price,
                typesOfClothes: clothes.TypeOfClothes,
                _context: _context);

            return RedirectToAction("Details", new { id });
        }

    }
}
