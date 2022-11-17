﻿using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

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
                if(cartItem.PromocodeId != null)
                cartItem.Promocode = _context.Promocodes.Where(x => x.Id == cartItem.PromocodeId).FirstOrDefault();
            }
            cart = cart.OrderByDescending(x => x.Id).ToList();
            return View(cart);
        }

        [System.Web.Http.HttpGet]
        public async Task<IActionResult> ApplyPromocode(string promo)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
               await  PromocodeRepository.ApplyPromocodeAsync(promo, userId, _context);
            }
            catch(Exception e)
            {
                if (e.Message.Contains("Invalid"))
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Promocode doesn't exist",
                        System.Text.Encoding.UTF8, "text/plain"),
                        StatusCode = HttpStatusCode.NotFound
                    };
                    throw new HttpResponseException(response);
                }
            }
            return Cart();
        }

        public IActionResult Orders()  //finished orders
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orders = _context.Carts.Where(x => x.ApplicationUserId == userId
            && x.IsOrderFinished == true).OrderByDescending(x=>x.Id).ToList();

            foreach (var order in orders)
            {
                //fill the clothes class into current order
                order.Clothes = _context.Clothes.Where(x => x.Id == order.ClothesId).FirstOrDefault();
            }

            return View(orders);
        }

        public IActionResult Ads()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var adsClothes = _context.Clothes.Where(x => x.SellerId == userId).OrderByDescending(x=>x.Id).ToList();
            return View(adsClothes);
        }
    }
}
