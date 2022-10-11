using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbAccessLibrary.Models
{
    public class Clothes
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
        public int Price { get; set; }
        public TypesOfClothes TypeOfClothes { get; set; }
        public Colors Color { get; set; }
        public byte[] PreviewImage { get; set; }

        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
