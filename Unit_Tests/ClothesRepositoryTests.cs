using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests
{
    public class ClothesRepositoryTests
    {
        [Test]
        public async Task CreateClothesTest()
        {
            //Arrange
            var ctx = MyLibrary.GetClothesStoreDbContext();

            var imageBytes = Encoding.UTF8.GetBytes("This is a file");

            string nameToAssert = "sweater";
            //Act
            await ClothesRepository.CreateAsync(
                name: nameToAssert,
                color: Colors.Blue,
                price: 1599,
                previewImage: imageBytes,
                typesOfClothes: TypesOfClothes.Hoodies,
                sellerId: 312,
                _context: ctx);

            var itemResult = ctx.Clothes.SingleOrDefault();

            //Asset
            Assert.AreEqual(nameToAssert, itemResult.Name);

            // delete items that remain in mock db and creating issues for next tests
            ctx.Clothes.Remove(itemResult);
            await ctx.SaveChangesAsync();
        }


        [Test]
        public async Task DeleteClothesTest()
        {
            //Arrange
            var ctx = MyLibrary.GetClothesStoreDbContext();
            Clothes clothes = MyLibrary.CreateClothesObject();

            await ctx.Clothes.AddAsync(clothes);
            await ctx.SaveChangesAsync();

            await ClothesRepository.DeleteAsync(clothes.Id, ctx);

            //Act
            var itemResult = ctx.Clothes.Where(x => x.Id == clothes.Id).SingleOrDefault();

            //Assert
            Assert.IsNull(itemResult);
        }

        [Test]
        public async Task GetByIdClothesTest()
        {
            //Arrange
            var ctx = MyLibrary.GetClothesStoreDbContext();
            Clothes clothes = MyLibrary.CreateClothesObject();
            await ctx.Clothes.AddAsync(clothes);
            await ctx.SaveChangesAsync();

            //Act
            var itemResult = ClothesRepository.GetById(clothes.Id,ctx);
            //Assert
            Assert.AreEqual(clothes.Name, itemResult.Name);

            // delete items that remain in mock db and creating issues for next tests
            ctx.Clothes.Remove(itemResult);
            await ctx.SaveChangesAsync();
        }


    }
}
