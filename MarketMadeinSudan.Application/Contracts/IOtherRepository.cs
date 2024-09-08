using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IOtherRepository : IAsyncRepository<Other>
    {
        Task<IReadOnlyList<Other>> GetAllOtherAsync();
        Task<Other> GetOtherByIdAsync(Guid OtherId);
    }
}