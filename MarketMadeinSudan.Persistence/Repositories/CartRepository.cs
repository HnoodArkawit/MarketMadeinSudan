using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<Cart>> GetAllCartAsync()
        {
            List<Cart> allAccessories = new List<Cart>();
            allAccessories = await _dbContext.Carts.ToListAsync();
            return allAccessories;
        }

        public async Task<Cart> GetCartByIdAsync(Guid id)
        {
            Cart Cart = new Cart();
            Cart = await GetByIdAsync(id);
            return Cart;
        }

    }
}
