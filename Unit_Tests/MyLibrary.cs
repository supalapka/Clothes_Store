using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace Unit_Tests
{
    public static class MyLibrary
    {
        public static ClothesStoreDbContext GetClothesStoreDbContext()
        {
            var options = new DbContextOptionsBuilder<ClothesStoreDbContext>()
            .UseInMemoryDatabase(databaseName: "database").Options;
            return new ClothesStoreDbContext(options);
        }

        public static Clothes CreateClothesObject(int? clothesId = null)
        {
            var bytes = Encoding.UTF8.GetBytes("This is an img file");
            int id = clothesId ?? 1;
            return new Clothes()
            {
                Id = id,
                Name = "123",
                SellerId = 3,
                Color = Colors.White,
                Price = 1900,
                TypeOfClothes = TypesOfClothes.Shoes,
                PreviewImage = bytes,
            };
        }

        public static ControllerContext CreateMockUserForController(string userId = null)
        {
            string id = userId ?? "SomeUserId";
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, id),
                                        new Claim(ClaimTypes.Name, "gunnar@somecompany.com")
                                   }, "TestAuthentication"));
            var controllerContext = new ControllerContext();
            controllerContext.HttpContext = new DefaultHttpContext { User = user };
            return controllerContext;
        }

    }
}
