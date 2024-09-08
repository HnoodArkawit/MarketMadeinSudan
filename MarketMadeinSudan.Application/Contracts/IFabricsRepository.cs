using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IFabricsRepository : IAsyncRepository<Fabrics>
    {
        Task<IReadOnlyList<Fabrics>> GetAllFabricsAsync();
        Task<Fabrics> GetFabricsByIdAsync(Guid FabricsId);
    }
}