using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class ShippingRepository : BaseRepository<Shipping>, IShippingRepository
    {
        public ShippingRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<Shipping>> GetAllShippingAsync()
        {
            List<Shipping> allShipping = new List<Shipping>();
            allShipping = await _dbContext.Shippings.ToListAsync();
            return allShipping;
        }

        public async Task<Shipping> GetShippingByIdAsync(Guid id)
        {
            Shipping Shipping = new Shipping();
            Shipping = await GetByIdAsync(id);
            return Shipping;
        }

    }
}
