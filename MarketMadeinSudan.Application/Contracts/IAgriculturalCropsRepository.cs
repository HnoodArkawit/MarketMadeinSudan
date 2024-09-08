using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IAgriculturalCropsRepository : IAsyncRepository<AgriculturalCrops>
    {
        Task<IReadOnlyList<AgriculturalCrops>> GetAllAgriculturalCropsAsync();
        Task<AgriculturalCrops> GetAgriculturalCropsByIdAsync(Guid AgriculturalCropsId);
    }
}

