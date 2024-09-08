using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IPublishersRepository : IAsyncRepository<Publishers>
    {
        Task<IReadOnlyList<Publishers>> GetAllPublishersAsync();
        Task<Publishers> GetPublishersByIdAsync(Guid PublishersId);
    }
}