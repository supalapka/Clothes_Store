using DbAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DbAccessLibrary.DbAccess
{
    public class ClotherStoreDbContext : DbContext
    {
        public ClotherStoreDbContext(DbContextOptions<ClotherStoreDbContext> options)
         : base(options)
        {
        }

        public DbSet<Clothes> Clothes { get; set; }

    }
}
