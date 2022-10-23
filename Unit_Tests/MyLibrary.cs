using DbAccessLibrary.DbAccess;
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

    }
}
