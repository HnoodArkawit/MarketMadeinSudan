using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IEnumerable<T> Search();
        List<Accessories> GetAccessoriesDataByUser(string UserId);
        List<AgriculturalCrops> GetAgriculturalCropsDataByUser(string UserId);
        List<Aspires> GetAspiresDataByUser(string UserId);
        List<ElectricalAndElctronic> GetElectricalAndElctronicDataByUser(string UserId);
        List<Fabrics> GetFabricsDataByUser(string UserId);
        List<Food> GetFoodDataByUser(string UserId);
        List<HouseholdProducts> GetHouseholdProductsDataByUser(string UserId);
        List<Other> GetOtherDataByUser(string UserId);
        List<SportAndEntertainment> GetSportAndEntertainmentDataByUser(string UserId);
        List<WatchesAndJewelry> GetWatchesAndJewelryDataByUser(string UserId);
        List<Publishers> GetPublishersDataByUser(string UserId);
        List<Cart> GetCartDataByUser(string UserId);
        List<OrderDetails> GetOrderDetailsDataByUser(string UserId);
        List<Advertisements> GetAdvertisementsDataByUser(string UserId);
        List<Shipping> GetShippingDataByUser(string UserId);
    }
}
