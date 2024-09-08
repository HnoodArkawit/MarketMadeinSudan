using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IWatchesAndJewelryRepository : IAsyncRepository<WatchesAndJewelry>
    {
        Task<IReadOnlyList<WatchesAndJewelry>> GetAllWatchesAndJewelryAsync();
        Task<WatchesAndJewelry> GetWatchesAndJewelryByIdAsync(Guid WatchesAndJewelryId);
    }
}