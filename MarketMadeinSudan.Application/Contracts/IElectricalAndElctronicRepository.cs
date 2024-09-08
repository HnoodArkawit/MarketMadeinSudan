
using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IElectricalAndElctronicRepository : IAsyncRepository<ElectricalAndElctronic>
    {
        Task<IReadOnlyList<ElectricalAndElctronic>> GetAllElectricalAndElctronicAsync();
        Task<ElectricalAndElctronic> GetElectricalAndElctronicByIdAsync(Guid ElectricalAndElctronicId);
    }
}
