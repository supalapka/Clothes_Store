using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessLibrary.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Clothes> Clothes { get; set; }
    }
}
