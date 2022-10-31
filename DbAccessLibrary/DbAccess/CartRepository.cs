using DbAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DbAccessLibrary.DbAccess
{
    public static class CartRepository
    {

        public static async Task CreateAsync(int clothesId, int quantity, Size size,
            string applicationUserId, ClothesStoreDbContext ctx)
        {
            var cart = new Cart()
            {
                ApplicationUserId = applicationUserId,
                Size = size,
                ClothesId = clothesId,
                Quantity = quantity,
                IsOrderFinished = false,
                Date = DateTime.Now,
            };
            await ctx.Carts.AddAsync(cart);
            await ctx.SaveChangesAsync();
        }

        public static async Task DeleteAsync(int id, ClothesStoreDbContext ctx)
        {
            var cart = ctx.Carts.FirstOrDefault(ctx => ctx.Id == id);
            ctx.Carts.Remove(cart);
            await ctx.SaveChangesAsync();
        }

        public static List<Cart> GetCartOfUser(string userId, ClothesStoreDbContext ctx)
        {
            var cart = ctx.Carts.Where(x => x.IsOrderFinished == false
            && x.ApplicationUserId == userId).ToList();
            return cart;
        }

        public static List<Cart> GetOrdersOfUser(string userId, ClothesStoreDbContext ctx)
        {
            var cart = ctx.Carts.Where(x => x.IsOrderFinished == true
            && x.ApplicationUserId == userId).ToList();
            return cart;
        }

        public static async Task FinishCurrentCartForUser(string userId, ClothesStoreDbContext ctx)
        {
            var cart = ctx.Carts.Where(x => x.IsOrderFinished == true
            && x.ApplicationUserId == userId).ToList();
            foreach (var cartItem in cart)
            {
                cartItem.IsOrderFinished = true;
                cartItem.Date = DateTime.Now;
            }
            await ctx.SaveChangesAsync();
        }

        public static async Task IncrementQuantity(int id, ClothesStoreDbContext ctx)
        {
            var cart = ctx.Carts.FirstOrDefault(cart => cart.Id == id);
            cart.Quantity++;
            await ctx.SaveChangesAsync();
        }

        public static async Task DecrementQuantity(int id, ClothesStoreDbContext ctx)
        {
            var cart = ctx.Carts.FirstOrDefault(cart => cart.Id == id);
            cart.Quantity--;
            if (cart.Quantity == 0)
                ctx.Carts.Remove(cart);
            await ctx.SaveChangesAsync();
        }
    }
}
