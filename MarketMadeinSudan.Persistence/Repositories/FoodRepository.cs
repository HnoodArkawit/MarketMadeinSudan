using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public class FoodRepository: BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(MarketMadeinSudanDbContext marketMadeinSudanDbContext) : base(marketMadeinSudanDbContext)
    {

    }
    public async Task<IReadOnlyList<Food>> GetAllFoodAsync()
    {
        List<Food> allFood = new List<Food>();
            allFood = await _dbContext.Foods.ToListAsync();
        return allFood;
    }

    public async Task<Food> GetFoodByIdAsync(Guid id)
    {
            Food Food = new Food();
            Food = await GetByIdAsync(id);
        return Food;
    }

}
}

