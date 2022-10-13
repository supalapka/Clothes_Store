using DbAccessLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessLibrary.DbAccess
{
    public static class ClothesRepository
    {

        public static async Task CreateAsync(string name, byte[] previewImage, TypesOfClothes typesOfClothes,
            Colors color, int sellerId, int price, ClothesStoreDbContext _context)
        {
            Clothes clothes = new Clothes()
            {
                Name = name,
                PreviewImage = previewImage,
                Price = price,
                SellerId = sellerId,
                TypeOfClothes = typesOfClothes,
                Color = color,
            };

            await _context.Clothes.AddAsync(clothes);
            await _context.SaveChangesAsync();
        }

        public static async Task DeleteAsync(int id, ClothesStoreDbContext _context)
        {
            var objToRm = _context.Clothes.Where(c => c.Id == id).FirstOrDefault();
            _context.Remove(objToRm);
            await _context.SaveChangesAsync();
        }
    }
}
