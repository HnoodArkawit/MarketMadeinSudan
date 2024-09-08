using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MarketMadeinSudan.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketMadeinSudan.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MarketMadeinSudanDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    //        services.AddDbContext<DbContext>(options =>
    //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IAccessoriesRepository), typeof(AccessoriesRepository));
            services.AddScoped(typeof(IAgriculturalCropsRepository), typeof(AgriculturalCropsRepository));
            services.AddScoped(typeof(IAspiresRepository), typeof(AspiresRepository));
            services.AddScoped(typeof(IElectricalAndElctronicRepository), typeof(ElectricalAndElctronicRepository));
            services.AddScoped(typeof(IFabricsRepository), typeof(FabricsRepository));
            services.AddScoped(typeof(IFoodRepository), typeof(FoodRepository));
            services.AddScoped(typeof(IHouseholdProductsRepository), typeof(HouseholdProductsRepository));
            services.AddScoped(typeof(IOtherRepository), typeof(OtherRepository));
            services.AddScoped(typeof(ISportAndEntertainmentRepository), typeof(SportAndEntertainmentRepository));
            services.AddScoped(typeof(IWatchesAndJewelryRepository), typeof(WatchesAndJewelryRepository));
            services.AddScoped(typeof(IPublishersRepository), typeof(PublishersRepository));
            services.AddScoped(typeof(ICartRepository), typeof(CartRepository));
            services.AddScoped(typeof(IOrderDetailsRepository), typeof(OrderDetailsRepository));
            services.AddScoped(typeof(IAdvertisementsRepository), typeof(AdvertisementsRepository));
            services.AddScoped(typeof(IShippingRepository), typeof(ShippingRepository));

            return services;
        }
    }
}
