
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class SportAndEntertainmentRepository : BaseRepository<SportAndEntertainment>, ISportAndEntertainmentRepository
    {
        public SportAndEntertainmentRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<SportAndEntertainment>> GetAllSportAndEntertainmentAsync()
        {
            List<SportAndEntertainment> allSportAndEntertainment = new List<SportAndEntertainment>();
            allSportAndEntertainment = await _dbContext.SportAndEntertainments.ToListAsync();
            return allSportAndEntertainment;
        }

        public async Task<SportAndEntertainment> GetSportAndEntertainmentByIdAsync(Guid id)
        {
            SportAndEntertainment SportAndEntertainment = new SportAndEntertainment();
            SportAndEntertainment = await GetByIdAsync(id);
            return SportAndEntertainment;
        }

    }
}

