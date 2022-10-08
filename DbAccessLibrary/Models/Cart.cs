using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessLibrary.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool IsOrderFinished { get; set; }
    }
}
