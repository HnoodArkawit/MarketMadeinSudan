using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class AccessoriesRepository : BaseRepository<Accessories>, IAccessoriesRepository
    {
        public AccessoriesRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<Accessories>> GetAllAccessoriesAsync()
        {
            List<Accessories> allAccessories = new List<Accessories>();
            allAccessories = await _dbContext.Accessoriess.ToListAsync();
            return allAccessories;
        }

        public async Task<Accessories> GetAccessoriesByIdAsync(Guid id)
        {
            Accessories Accessories = new Accessories();
            Accessories = await GetByIdAsync(id);
            return Accessories;
        }

    }
}
