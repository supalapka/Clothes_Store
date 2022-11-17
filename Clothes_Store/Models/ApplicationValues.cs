using DbAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Store.Models
{
    public class ApplicationValues
    {
        public List<Clothes> clothes { get; set; }
        public int CoutnUser { get; set; }
        public int Amount_money_spent { get; set; }
        public int AveragePrice { get; set; }
    }
}
