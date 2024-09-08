using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
        {

        }
        public async Task<IReadOnlyList<OrderDetails>> GetAllOrderDetailsAsync()
        {
            List<OrderDetails> allOrderDetails = new List<OrderDetails>();
            allOrderDetails =await _dbContext.OrderDetailss.ToListAsync();
            return allOrderDetails;
        }

        public async Task<OrderDetails> GetOrderDetailsByIdAsync(Guid id)
        {
            OrderDetails OrderDetails = new OrderDetails();
            OrderDetails =  await GetByIdAsync(id);
            return OrderDetails;
        }

    }
}
