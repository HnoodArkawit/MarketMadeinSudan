using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IShippingRepository : IAsyncRepository<Shipping>
    {
        Task<IReadOnlyList<Shipping>> GetAllShippingAsync();
        Task<Shipping> GetShippingByIdAsync(Guid ShippingId);
    }
}