using DbAccessLibrary.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessLibrary.DbAccess
{
    public class PromocodeRepository
    {
        public static async Task ApplyPromocodeAsync(string _promo, string userId, ClothesStoreDbContext ctx)
        {
            Promocode promocode;
            try { promocode = GetPromocodeByCode(_promo, ctx); }
            catch { throw new Exception("Invalid promocode"); }

            if (IsUserHaveUsedPromo(promocode.Id, userId, ctx))
                throw new Exception("Promocode allready used");

            var cart = CartRepository.GetCartOfUser(userId, ctx);
            bool isPromoApplied = false;
            foreach (var cartItem in cart)
            {
                //fill clothes class for get clothes category and apply discount for price
                var clothes = ClothesRepository.GetById(cartItem.ClothesId, ctx);
                if (clothes.Category == promocode.Category)
                {
                    cartItem.PromocodeId = promocode.Id;
                    if (!isPromoApplied)
                    {
                        //mark promocode as used, but its still works for current cart
                        await ctx.UsedPromocodes.AddAsync(new UsedPromocode()
                        {
                            ApplicationUserId = userId,
                            PromocodeId = promocode.Id,
                        });
                        isPromoApplied = true;
                    }
                }
            }

            if (!isPromoApplied)
                throw new Exception("There is no clothing category to apply the promocode");
            else
                await ctx.SaveChangesAsync();
        }

        public static Promocode GetPromocodeByCode(string _promo, ClothesStoreDbContext ctx)
        {
            var promocode = ctx.Promocodes.SingleOrDefault(x => x.Code == _promo);
            if (promocode == null)
                throw new Exception();
            else
                return promocode;
        }

        public static Promocode GetPromocodeById(int id, ClothesStoreDbContext ctx)
        {
            var promocode = ctx.Promocodes.SingleOrDefault(x => x.Id == id);
            return promocode;
        }


        private static bool IsUserHaveUsedPromo(int promoId, string userId, ClothesStoreDbContext ctx)
        {
            var isPromoUsed = ctx.UsedPromocodes.SingleOrDefault(x => x.PromocodeId == promoId
           && x.ApplicationUserId == userId);
            if (isPromoUsed == null)
                return false;
            return true;
        }


    }
}
