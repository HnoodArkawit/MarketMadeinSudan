using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class AspiresRepository : BaseRepository<Aspires>, IAspiresRepository
    {
        public AspiresRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<Aspires>> GetAllAspiresAsync()
        {
            List<Aspires> allAspires = new List<Aspires>();
            allAspires = await _dbContext.Aspires.ToListAsync();
            return allAspires;
        }

        public async Task<Aspires> GetAspiresByIdAsync(Guid id)
        {
            Aspires Aspires = new Aspires();
            Aspires = await GetByIdAsync(id);
            return Aspires;
        }

    }
}

