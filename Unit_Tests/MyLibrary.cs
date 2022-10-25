using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public static Clothes CreateClothesObject()
        {
            var bytes = Encoding.UTF8.GetBytes("This is an img file");
            return new Clothes()
            {
                Id = 1,
                Name = "123",
                SellerId = 3,
                Color = Colors.White,
                Price = 1900,
                TypeOfClothes = TypesOfClothes.Boots,
                PreviewImage = bytes,
            };
        }

    }
}
