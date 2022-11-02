using DbAccessLibrary.DbAccess;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        public async Task FinishCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await CartRepository.FinishCurrentCartForUser(userId, _context);
        }
    }
}
