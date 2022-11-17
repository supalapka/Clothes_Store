using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class FunctionsLib
    {

        public static byte[] FileToByteArrayAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())  //convert imageFile to byte[] for storing in db
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    return fileBytes;
                }
            }
        }

        public static string GetImageSourceFromBytes(byte[] bytes)
        {
            var base64 = Convert.ToBase64String(bytes);
            return String.Format("data:image/jpg;base64,{0}", base64);
        }


    }
}
