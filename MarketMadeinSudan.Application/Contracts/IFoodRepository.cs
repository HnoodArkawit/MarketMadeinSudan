using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IFoodRepository : IAsyncRepository<Food>
    {
        Task<IReadOnlyList<Food>> GetAllFoodAsync();
        Task<Food> GetFoodByIdAsync(Guid FoodId);
    }
}