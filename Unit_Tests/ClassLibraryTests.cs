using ClassLibrary;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Unit_Tests
{
    public class ClassLibraryTests
    {
        //[SetUp]
        //public void Setup()
        //{

        //}

        [Test]
        public void FileToByteArrayAsync_Works()
        {
            //Arrange
            var bytes = Encoding.UTF8.GetBytes("This is a file");
            IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "IFormFile.txt");

            //Act
            var bytesResult = FunctionsLib.FileToByteArrayAsync(file);
            //Assert
            Assert.AreEqual(bytesResult, bytes);
        }

        public void GetImageSourceFromBytes_Works()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
