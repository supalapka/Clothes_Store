using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Clothes_Store.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
