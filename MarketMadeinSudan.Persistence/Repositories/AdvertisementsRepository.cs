using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class AdvertisementsRepository : BaseRepository<Advertisements>, IAdvertisementsRepository
    {
        public AdvertisementsRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<Advertisements>> GetAllAdvertisementsAsync()
        {
            List<Advertisements> allAdvertisements = new List<Advertisements>();
            allAdvertisements = await _dbContext.Advertisementss.ToListAsync();
            return allAdvertisements;
        }

        public async Task<Advertisements> GetAdvertisementsByIdAsync(Guid id)
        {
            Advertisements Advertisements = new Advertisements();
            Advertisements = await GetByIdAsync(id);
            return Advertisements;
        }

    }
}
