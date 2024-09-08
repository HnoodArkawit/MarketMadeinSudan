using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class ElectricalAndElctronicRepository : BaseRepository<ElectricalAndElctronic>, IElectricalAndElctronicRepository
    {
        public ElectricalAndElctronicRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<ElectricalAndElctronic>> GetAllElectricalAndElctronicAsync()
        {
            List<ElectricalAndElctronic> allElectricalAndElctronic = new List<ElectricalAndElctronic>();
            allElectricalAndElctronic = await _dbContext.ElectricalAndElctronics.ToListAsync();
            return allElectricalAndElctronic;
        }

        public async Task<ElectricalAndElctronic> GetElectricalAndElctronicByIdAsync(Guid id)
        {
            ElectricalAndElctronic ElectricalAndElctronic = new ElectricalAndElctronic();
            ElectricalAndElctronic = await GetByIdAsync(id);
            return ElectricalAndElctronic;
        }

    }
}

