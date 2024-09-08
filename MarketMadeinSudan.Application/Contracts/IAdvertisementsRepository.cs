using MarketMadeinSudan.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IAdvertisementsRepository : IAsyncRepository<Advertisements>
    {
        Task<IReadOnlyList<Advertisements>> GetAllAdvertisementsAsync();
        Task<Advertisements> GetAdvertisementsByIdAsync(Guid AdvertisementsId);
    }
}