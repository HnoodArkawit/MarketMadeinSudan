using MarketMadeinSudan.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IAccessoriesRepository : IAsyncRepository<Accessories>
    {
        Task<IReadOnlyList<Accessories>> GetAllAccessoriesAsync();
        Task<Accessories> GetAccessoriesByIdAsync(Guid AccessoriesId);
    }
}