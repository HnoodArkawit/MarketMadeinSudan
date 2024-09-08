using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface ISportAndEntertainmentRepository : IAsyncRepository<SportAndEntertainment>
    {
        Task<IReadOnlyList<SportAndEntertainment>> GetAllSportAndEntertainmentAsync();
        Task<SportAndEntertainment> GetSportAndEntertainmentByIdAsync(Guid SportAndEntertainmentId);
    }
}
