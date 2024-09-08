
using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IOrderDetailsRepository : IAsyncRepository<OrderDetails>
    {
        Task<IReadOnlyList<OrderDetails>> GetAllOrderDetailsAsync();
        Task<OrderDetails> GetOrderDetailsByIdAsync(Guid OrderDetailsId);
    }
}
