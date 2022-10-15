using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessLibrary.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Size Size { get; set; }
        public bool IsOrderFinished { get; set; }

        public int ClothesId { get; set; }
        public Clothes Clothes { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
