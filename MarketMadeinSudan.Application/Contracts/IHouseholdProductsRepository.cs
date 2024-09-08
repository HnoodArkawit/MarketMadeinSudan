using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IHouseholdProductsRepository : IAsyncRepository<HouseholdProducts>
    {
        Task<IReadOnlyList<HouseholdProducts>> GetAllHouseholdProductsAsync();
        Task<HouseholdProducts> GetHouseholdProductsByIdAsync(Guid HouseholdProductsId);
    }
}