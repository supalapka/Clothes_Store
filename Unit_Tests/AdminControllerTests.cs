using Clothes_Store.Controllers;
using Clothes_Store.Models;
using DbAccessLibrary.DbAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests
{
    public class AdminControllerTests
    {
        [Test]
        public async Task AddClothes_Work()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ClothesStoreDbContext>()
             .UseInMemoryDatabase(databaseName: "Clothes_Store").Options;
            var ctx = new ClothesStoreDbContext(options);
            var adminController = new AdminController(ctx);

            var bytes = Encoding.UTF8.GetBytes("This is a file");
            IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "IFormFile.txt");

            ClothesPreview item = new ClothesPreview()
            {
                Id = 1,
                Color = DbAccessLibrary.Models.Colors.Blue,
                SellerName = "123",
                Name = "sweater",
                Price = 1599,
                PreviwImageFileInput = file,
                TypeOfClothes = DbAccessLibrary.Models.TypesOfClothes.Jacket,
            };
            //Act
            await adminController.AddClothes(item); //
            var itemResult = ctx.Clothes.Where(x => x.Id == item.Id).SingleOrDefault(); //get item from db for assert

            //Asset
            Assert.AreEqual(item.Name, itemResult.Name);

        }
    }
}
