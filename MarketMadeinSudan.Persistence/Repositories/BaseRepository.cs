using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderCart.Commands.CreateCart;
using MarketMadeinSudan.Domin;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MarketMadeinSudan.Persistence.Repositories
{
    public partial class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MarketMadeinSudanDbContext _dbContext;

        public BaseRepository(MarketMadeinSudanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }
        public IEnumerable<T> Search()
        {
            return _dbContext.Set<T>().ToList();
        }
        public List<Accessories> GetAccessoriesDataByUser(string UserId)
        {
                return _dbContext.Accessoriess.Where(x => x.UserId == UserId).ToList();
        }
        public List<AgriculturalCrops> GetAgriculturalCropsDataByUser(string UserId)
        {
            return _dbContext.AgriculturalCropss.Where(x => x.UserId == UserId).ToList();
        }
        public List<Aspires> GetAspiresDataByUser(string UserId)
        {
            return _dbContext.Aspires.Where(x => x.UserId == UserId).ToList();
        }
        public List<ElectricalAndElctronic> GetElectricalAndElctronicDataByUser(string UserId)
        {
            return _dbContext.ElectricalAndElctronics.Where(x => x.UserId == UserId).ToList();
        }
        public List<Fabrics> GetFabricsDataByUser(string UserId)
        {
            return _dbContext.Fabricss.Where(x => x.UserId == UserId).ToList();
        }
        public List<Food> GetFoodDataByUser(string UserId)
        {
            return _dbContext.Foods.Where(x => x.UserId == UserId).ToList();
        }
        public List<HouseholdProducts> GetHouseholdProductsDataByUser(string UserId)
        {
            return _dbContext.HouseholdProductss.Where(x => x.UserId == UserId).ToList();
        }
        public List<Other> GetOtherDataByUser(string UserId)
        {
            return _dbContext.Others.Where(x => x.UserId == UserId).ToList();
        }
        public List<SportAndEntertainment> GetSportAndEntertainmentDataByUser(string UserId)
        {
            return _dbContext.SportAndEntertainments.Where(x => x.UserId == UserId).ToList();
        }
        public List<WatchesAndJewelry> GetWatchesAndJewelryDataByUser(string UserId)
        {
            return _dbContext.WatchesAndJewelrys.Where(x => x.UserId == UserId).ToList();
        }
        public List<Publishers> GetPublishersDataByUser(string UserId)
        {
            return _dbContext.Publisherss.Where(x => x.UserId == UserId).ToList();
        }
        public List<Cart> GetCartDataByUser(string UserId)
        {
            return _dbContext.Carts.Where(x => x.UserId == UserId).ToList();
        }
        public List<OrderDetails> GetOrderDetailsDataByUser(string UserId)
        {
            return _dbContext.OrderDetailss.Where(x => x.UserId == UserId).ToList();
        }
        public List<Advertisements> GetAdvertisementsDataByUser(string UserId)
        {
            return _dbContext.Advertisementss.Where(x => x.UserId == UserId).ToList();
        }
        public List<Shipping> GetShippingDataByUser(string UserId)
        {
            return _dbContext.Shippings.Where(x => x.UserId == UserId).ToList();
        }

    }
}
