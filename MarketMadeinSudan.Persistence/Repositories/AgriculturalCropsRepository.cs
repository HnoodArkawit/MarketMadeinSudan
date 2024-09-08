using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class AgriculturalCropsRepository : BaseRepository<AgriculturalCrops>, IAgriculturalCropsRepository
    {
        public AgriculturalCropsRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<AgriculturalCrops>> GetAllAgriculturalCropsAsync()
        {
            List<AgriculturalCrops> allAgriculturalCrops = new List<AgriculturalCrops>();
            allAgriculturalCrops = await _dbContext.AgriculturalCropss.ToListAsync();
            return allAgriculturalCrops;
        }

        public async Task<AgriculturalCrops> GetAgriculturalCropsByIdAsync(Guid id)
        {
            AgriculturalCrops AgriculturalCrops = new AgriculturalCrops();
            AgriculturalCrops = await GetByIdAsync(id);
            return AgriculturalCrops;
        }

    }
}
