using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IAspiresRepository : IAsyncRepository<Aspires>
    {
        Task<IReadOnlyList<Aspires>> GetAllAspiresAsync();
        Task<Aspires> GetAspiresByIdAsync(Guid AspiresId);
    }
}
