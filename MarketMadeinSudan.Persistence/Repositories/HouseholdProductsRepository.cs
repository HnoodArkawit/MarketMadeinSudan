using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class HouseholdProductsRepository : BaseRepository<HouseholdProducts>, IHouseholdProductsRepository
    {
        public HouseholdProductsRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<HouseholdProducts>> GetAllHouseholdProductsAsync()
        {
            List<HouseholdProducts> allHouseholdProducts = new List<HouseholdProducts>();
            allHouseholdProducts = await _dbContext.HouseholdProductss.ToListAsync();
            return allHouseholdProducts;
        }

        public async Task<HouseholdProducts> GetHouseholdProductsByIdAsync(Guid id)
        {
            HouseholdProducts HouseholdProducts = new HouseholdProducts();
            HouseholdProducts = await GetByIdAsync(id);
            return HouseholdProducts;
        }

    }
}

