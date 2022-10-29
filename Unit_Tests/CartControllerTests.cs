using Clothes_Store.Controllers;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests
{
    public class CartControllerTests
    {
        [Test]
        public async Task AddToCart_Work()
        {
            //Arrange
            var ctx = MyLibrary.GetClothesStoreDbContext();
            var controller = new CartController(ctx);

            var bytes = Encoding.UTF8.GetBytes("This is an img file");
            Clothes clothes = MyLibrary.CreateClothesObject();

            await ctx.Clothes.AddAsync(clothes);
            await ctx.SaveChangesAsync();
            controller.ControllerContext = MyLibrary.CreateMockUserForController("SomeUserId");

            //Act
            await controller.AddToCart(clothes.Id);
            var itemResult = ctx.Carts.SingleOrDefault(); //get item from db for assert

            //Asset
            Assert.AreEqual(clothes.Id, itemResult.ClothesId);

            // delete items that remain in mock db and creating issues for next tests
            ctx.Clothes.Remove(clothes);
            await ctx.SaveChangesAsync();
        }


        [Test]
        public async Task DeleteFromCart_Work()
        {
            //Arrange
            var ctx = MyLibrary.GetClothesStoreDbContext();
            var controller = new CartController(ctx);

            var cart = new Cart()
            {
                Id = 1,
                ClothesId = 90,
                ApplicationUserId = "SomeUserId", //UserId is sets on Claim(ClaimTypes.NameIdentifier, "SomeUserId"),!!
                Date = DateTime.Now,
                Size = Size.S,
                Quantity = 2,
                IsOrderFinished = false,
            };
            await ctx.Carts.AddAsync(cart);
            await ctx.SaveChangesAsync();
        }


    }
}
