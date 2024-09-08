using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class PublishersRepository : BaseRepository<Publishers>, IPublishersRepository
    {
        public PublishersRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<Publishers>> GetAllPublishersAsync()
        {
            List<Publishers> allPublishers = new List<Publishers>();
            allPublishers = await _dbContext.Publisherss.ToListAsync();
            return allPublishers;
        }

        public async Task<Publishers> GetPublishersByIdAsync(Guid id)
        {
            Publishers Publishers = new Publishers();
            Publishers = await GetByIdAsync(id);
            return Publishers;
        }

    }
}
