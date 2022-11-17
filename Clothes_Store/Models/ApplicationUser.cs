using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Clothes_Store.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeliveryAddress { get; set; }

        public List<Cart> Carts { get; set; }
        public List<UsedPromocode> UsedPromocodes { get; set; }
    }

}
