using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Clothes_Store.Models
{
    public class ClothesPreview
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public TypesOfClothes TypeOfClothes { get; set; }

        [Required]
        public Colors Color { get; set; }

        [Required]
        public string SellerName { get; set; }

        public byte[] PreviewImageOutput { get; set; } //image that shows

        [Required]
        public IFormFile PreviwImageFileInput { get; set; } //image for uploads while adding clothes
    }
}
