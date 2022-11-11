using DbAccessLibrary.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DbAccessLibrary.DbAccess
{
    public static class ClothesRepository
    {
        public static async Task CreateAsync(string name, byte[] previewImage, TypesOfClothes typesOfClothes,
            Colors color, string sellerId, int price, Gender gender, ClothingCategory clothingCategory,
            ClothesStoreDbContext _context)
        {
            Clothes clothes = new Clothes()
            {
                Name = name,
                PreviewImage = previewImage,
                Price = price,
                SellerId = sellerId,
                TypeOfClothes = typesOfClothes,
                Color = color,
                Gender = gender,
                Category = clothingCategory,
            };

            await _context.Clothes.AddAsync(clothes);
            await _context.SaveChangesAsync();
        }

        public static async Task<int> CreateAndReturnIdAsync(string name, byte[] previewImage, TypesOfClothes typesOfClothes,
            Colors color, string sellerId, int price, Gender gender, ClothingCategory clothingCategory,
            ClothesStoreDbContext _context)
        {
            Clothes clothes = new Clothes()
            {
                Name = name,
                PreviewImage = previewImage,
                Price = price,
                SellerId = sellerId,
                TypeOfClothes = typesOfClothes,
                Color = color,
                Gender = gender,
                Category = clothingCategory,
            };

            await _context.Clothes.AddAsync(clothes);
            await _context.SaveChangesAsync();

            return clothes.Id;
        }

        public static async Task DeleteAsync(int id, ClothesStoreDbContext _context)
        {
            var objToRm = _context.Clothes.Where(c => c.Id == id).FirstOrDefault();
            _context.Remove(objToRm);
            await _context.SaveChangesAsync();
        }

        public static Clothes GetById(int id, ClothesStoreDbContext _context)
        {
            var clothes = _context.Clothes.Where(x => x.Id == id).FirstOrDefault();
            return clothes;
        }

        public static List<Clothes> GetBySearchString(string request, ClothesStoreDbContext ctx)
        {
            var allClothes = ctx.Clothes.ToList();
            var clothesResult = new List<Clothes>();
            foreach (var item in allClothes)
            {
                if (GetDisplayNameFromEnum(item.TypeOfClothes).Contains(request) ||
                    GetDisplayNameFromEnum(item.Category).Contains(request))
                    clothesResult.Add(item);
            }
            return clothesResult;
        }

        public static string GetDisplayNameFromEnum<T>(T enum1)
        {
            FieldInfo field = enum1.GetType().GetField(enum1.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(DisplayAttribute), true);
            string name = ((DisplayAttribute)attribs[0]).GetName();
            return name;
        }
    }
}
