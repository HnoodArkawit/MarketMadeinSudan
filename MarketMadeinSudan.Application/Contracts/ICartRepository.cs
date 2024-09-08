using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface ICartRepository : IAsyncRepository<Cart>
    {
        Task<IReadOnlyList<Cart>> GetAllCartAsync();
        Task<Cart> GetCartByIdAsync(Guid CartId);
    }
}