using DbAccessLibrary.DbAccess;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clothes_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly ClothesStoreDbContext _context;

        public CartController(ClothesStoreDbContext context)
        {
            _context = context;
        }

        public async Task IncrementItemQuantity(int cartId)
        {
            await CartRepository.IncrementQuantity(cartId,_context);
        }

        public async Task DecrementItemQuantity(int cartId)
        {
            await CartRepository.DecrementQuantity(cartId, _context);
        }
    }
}
