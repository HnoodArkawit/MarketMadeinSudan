using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class FabricsRepository : BaseRepository<Fabrics>, IFabricsRepository
    {
        public FabricsRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<Fabrics>> GetAllFabricsAsync()
        {
            List<Fabrics> allFabrics = new List<Fabrics>();
            allFabrics = await _dbContext.Fabricss.ToListAsync();
            return allFabrics;
        }

        public async Task<Fabrics> GetFabricsByIdAsync(Guid id)
        {
            Fabrics Fabrics = new Fabrics();
            Fabrics = await GetByIdAsync(id);
            return Fabrics;
        }

    }
}
