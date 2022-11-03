using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbAccessLibrary.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Size Size { get; set; }
        public DateTime Date { get; set; }

        public bool IsOrderFinished { get; set; }

        public int ClothesId { get; set; }
        public Clothes Clothes { get; set; }

        public string ApplicationUserId { get; set; }

        public int PromocodeId { get; set; }
        [ForeignKey("PromocodeId")]
        public Promocode Promocode { get; set; }
    }
}
