
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class OtherRepository : BaseRepository<Other>, IOtherRepository
    {
        public OtherRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<Other>> GetAllOtherAsync()
        {
            List<Other> allOther = new List<Other>();
            allOther = await _dbContext.Others.ToListAsync();
            return allOther;
        }

        public async Task<Other> GetOtherByIdAsync(Guid id)
        {
            Other Other = new Other();
            Other = await GetByIdAsync(id);
            return Other;
        }

    }
}

