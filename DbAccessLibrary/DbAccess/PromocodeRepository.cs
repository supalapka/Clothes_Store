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
            try {  promocode = GetPromocode(_promo, ctx); }
            catch { throw new Exception("Invalid promocode"); }
           
            if (IsUserHaveUsedPromo(promocode.Id, userId, ctx))
                throw new Exception("Promocode allready used");

            var cart = CartRepository.GetCartOfUser(userId, ctx);
            bool isPromoApplied = false;
            foreach (var item in cart)
            {
                //fill clothes class for get clothes category and apply disdiscountscount for price
                item.Clothes = ClothesRepository.GetById(item.ClothesId, ctx);
                if (item.Clothes.Category == promocode.Category)
                {
                    int discount = (item.Clothes.Price / 100) * promocode.DiscountPercentage;
                    item.Clothes.Price -= discount;

                    if (!isPromoApplied)
                    {
                        //mark promocode as used, but still works for current cart
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

        public static Promocode GetPromocode(string _promo, ClothesStoreDbContext ctx)
        {
            var promocode = ctx.Promocodes.SingleOrDefault(x => x.Code == _promo);
            if (promocode == null)
                throw new Exception();
            else 
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
