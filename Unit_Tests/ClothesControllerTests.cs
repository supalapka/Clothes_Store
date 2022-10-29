using Clothes_Store.Controllers;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Unit_Tests
{
    public class ClothesControllerTests
    {
        [Test]
        public async Task ShowDetails_ValidItems()
        {
            //Arrange
            var ctx = MyLibrary.GetClothesStoreDbContext();
            var controller = new ClothesController(ctx);
            int clothesId = 5;
            Clothes originalClothes = MyLibrary.CreateClothesObject(clothesId);
            var clothesCopy = new Clothes() //this object will be changed controller.ClothesDetails cause of ref
            {
                Id = originalClothes.Id,
                Name = originalClothes.Name,
                SellerId = originalClothes.SellerId,
                Color = originalClothes.Color,
                Price = originalClothes.Price,
                PreviewImage = originalClothes.PreviewImage,
                TypeOfClothes = originalClothes.TypeOfClothes
            };
            await ctx.Clothes.AddAsync(clothesCopy);
            await ctx.SaveChangesAsync();

            //Act
            var result = controller.ClothesDetails(5) as ViewResult;
            Clothes clothesResult = result.Model as Clothes;

            // delete items that remain in mock db and creating issues for next tests
            ctx.Clothes.Remove(clothesCopy);
            await ctx.SaveChangesAsync();

            //Assert
            Assert.AreEqual(originalClothes.Id, clothesResult.Id);
            Assert.AreEqual(originalClothes.Name, clothesResult.Name);
            Assert.AreEqual(originalClothes.SellerId, clothesResult.SellerId);
            Assert.AreEqual(originalClothes.Color, clothesResult.Color);
            Assert.AreEqual(originalClothes.TypeOfClothes, clothesResult.TypeOfClothes);
            Assert.AreEqual(originalClothes.PreviewImage, clothesResult.PreviewImage);
            Assert.AreEqual(originalClothes.Price, clothesResult.Price);
        }

        [Test]
        public async Task AddToCart_CartAddedToDb()
        {
            //Arrange
            var ctx = MyLibrary.GetClothesStoreDbContext();
            var controller = new ClothesController(ctx);

            var clothes = MyLibrary.CreateClothesObject();
            await ctx.Clothes.AddAsync(clothes);
            await ctx.SaveChangesAsync();

            int clothesQuantity = 2;
            Size clothesSize = Size.XL;

            //Act
            controller.AddToCart(clothes.Id, clothesQuantity, clothesSize);
            var result = ctx.Carts.SingleOrDefault();

            // delete items that remain in mock db and creating issues for next tests
            ctx.Clothes.Remove(clothes);
            await ctx.SaveChangesAsync();
            if (result != null)
                ctx.Carts.Remove(result);

            //Assert
            Assert.AreEqual(clothes.Id, result.ClothesId);
        }
    }
}
