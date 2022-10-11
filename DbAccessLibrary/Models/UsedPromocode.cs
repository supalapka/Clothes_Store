using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbAccessLibrary.Models
{
    public class UsedPromocode
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public int PromocodeId { get; set; }
        [ForeignKey("PromocodeId")]
        public Promocode Promocode { get; set; }
    }
}
