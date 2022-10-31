using DbAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DbAccessLibrary.DbAccess
{
    public class CartRepository
    {
        public async Task CreateAsync(int clothesId, int quantity, Size size,
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

        public async Task DeleteAsync(int id, ClothesStoreDbContext ctx)
        {
            var cart = ctx.Carts.FirstOrDefault(ctx => ctx.Id == id);
            ctx.Carts.Remove(cart);
            await ctx.SaveChangesAsync();
        }

        public List<Cart> GetCartOfUser(string userId, ClothesStoreDbContext ctx)
        {
            var cart = ctx.Carts.Where(x => x.IsOrderFinished == false
            && x.ApplicationUserId == userId).ToList();
            return cart;
        }

        public List<Cart> GetOrdersOfUser(string userId, ClothesStoreDbContext ctx)
        {
            var cart = ctx.Carts.Where(x => x.IsOrderFinished == true
            && x.ApplicationUserId == userId).ToList();
            return cart;
        }

        public async Task FinishCurrentCartForUser(string userId, ClothesStoreDbContext ctx)
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
    }
}
