using DbAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DbAccessLibrary.DbAccess
{
    public class ClothesStoreDbContext : DbContext
    {
        public ClothesStoreDbContext(DbContextOptions<ClothesStoreDbContext> options)
         : base(options)
        {
        }

        public DbSet<Clothes> Clothes { get; set; }
        //public DbSet<Seller> Sellers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }
        public DbSet<UsedPromocode> UsedPromocodes { get; set; }
    }
}
