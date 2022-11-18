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
        public ClothingCategory Category { get; set; }
        public Gender Gender { get; set; }
        public Colors Color { get; set; }
        public byte[] PreviewImage { get; set; }
        public string SellerId { get; set; }
        public int Rating { get; set; }
        public int CountSell { get; set; }
        public bool ChoosedClothes { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
