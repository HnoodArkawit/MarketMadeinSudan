
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class WatchesAndJewelryRepository : BaseRepository<WatchesAndJewelry>, IWatchesAndJewelryRepository
    {
        public WatchesAndJewelryRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<WatchesAndJewelry>> GetAllWatchesAndJewelryAsync()
        {
            List<WatchesAndJewelry> allWatchesAndJewelry = new List<WatchesAndJewelry>();
            allWatchesAndJewelry = await _dbContext.WatchesAndJewelrys.ToListAsync();
            return allWatchesAndJewelry;
        }

        public async Task<WatchesAndJewelry> GetWatchesAndJewelryByIdAsync(Guid id)
        {
            WatchesAndJewelry WatchesAndJewelry = new WatchesAndJewelry();
            WatchesAndJewelry = await GetByIdAsync(id);
            return WatchesAndJewelry;
        }

    }
}
