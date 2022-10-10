using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessLibrary.Models
{
    public class Promocode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public ClothingCtegory Category { get; set; }

        public ICollection<UsedPromocode> Promocodes { get; set; }

    }
}
