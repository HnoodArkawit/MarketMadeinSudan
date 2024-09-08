using AutoMapper;
using MarketMadeinSudan.Application.Features.FolderAccessories.Commands.CreateAccessories;
using MarketMadeinSudan.Application.Features.FolderAccessories.Commands.DeleteAccessories;
using MarketMadeinSudan.Application.Features.FolderAccessories.Commands.UpdateAccessories;
using MarketMadeinSudan.Application.Features.FolderAccessories.Queries.GetAccessoriesDetail;
using MarketMadeinSudan.Application.Features.FolderAccessories.Queries.GetAccessoriesList;
using MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Commands.CreateAgriculturalCrops;
using MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Commands.DeleteAgriculturalCrops;
using MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Commands.UpdateAgriculturalCrops;
using MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Queries.GetAgriculturalCropsDetail;
using MarketMadeinSudan.Application.Features.FolderAspires.Commands.CreateAspires;
using MarketMadeinSudan.Application.Features.FolderAspires.Commands.DeleteAspires;
using MarketMadeinSudan.Application.Features.FolderAspires.Commands.GetAspiresDetail;
using MarketMadeinSudan.Application.Features.FolderAspires.Commands.GetAspiresList;
using MarketMadeinSudan.Application.Features.FolderAspires.Commands.UpdateAspires;
using MarketMadeinSudan.Application.Features.FolderCart.Commands.CreateCart;
using MarketMadeinSudan.Application.Features.FolderCart.Commands.DeleteCart;
using MarketMadeinSudan.Application.Features.FolderCart.Commands.UpdateCart;
using MarketMadeinSudan.Application.Features.FolderCart.Queries.GetCartDetail;
using MarketMadeinSudan.Application.Features.FolderCart.Queries.GetCartList;
using MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.CreateElectricalAndElctronic;
using MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.DeleteElectricalAndElctronic;
using MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.GetElectricalAndElctronicDetail;
using MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.GetElectricalAndElctronicList;
using MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.UpdateElectricalAndElctronic;
using MarketMadeinSudan.Application.Features.FolderFabrics.Commands.CreateFabrics;
using MarketMadeinSudan.Application.Features.FolderFabrics.Commands.DeleteFabrics;
using MarketMadeinSudan.Application.Features.FolderFabrics.Commands.UpdateFabrics;
using MarketMadeinSudan.Application.Features.FolderFabrics.Queries.GetFabricsDetail;
using MarketMadeinSudan.Application.Features.FolderFabrics.Queries.GetFabricsList;
using MarketMadeinSudan.Application.Features.FolderFood.Commands.CreateFood;
using MarketMadeinSudan.Application.Features.FolderFood.Commands.DeleteFood;
using MarketMadeinSudan.Application.Features.FolderFood.Commands.UpdateFood;
using MarketMadeinSudan.Application.Features.FolderFood.Queries.GetFoodDetail;
using MarketMadeinSudan.Application.Features.FolderFood.Queries.GetFoodList;
using MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Commands.CreateHouseholdProducts;
using MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Commands.DeleteHouseholdProducts;
using MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Commands.UpdateHouseholdProducts;
using MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Queries.GetHouseholdProductsDetail;
using MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Queries.GetHouseholdProductsList;
using MarketMadeinSudan.Application.Features.FolderOther.Commands.CreateOther;
using MarketMadeinSudan.Application.Features.FolderOther.Commands.DeleteOther;
using MarketMadeinSudan.Application.Features.FolderOther.Commands.UpdateOther;
using MarketMadeinSudan.Application.Features.FolderOther.Queries.GetOtherDetail;
using MarketMadeinSudan.Application.Features.FolderOther.Queries.GetOtherList;
using MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.CreateOrderDetails;
using MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.DeleteOrderDetails;
using MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.UpdateOrderDetails;
using MarketMadeinSudan.Application.Features.FolderOrderDetails.Queries.GetOrderDetailsDetail;
using MarketMadeinSudan.Application.Features.FolderOrderDetails.Queries.GetOrderDetailsList;
using MarketMadeinSudan.Application.Features.FolderPublishers.Queries.GetPublishersList;
using MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Commands.CreateSportAndEntertainment;
using MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Commands.DeleteSportAndEntertainment;
using MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Commands.UpdateSportAndEntertainment;
using MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Queries.GetSportAndEntertainmentDetail;
using MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Queries.GetSportAndEntertainmentList;
using MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Commands.CreateWatchesAndJewelry;
using MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Commands.DeleteWatchesAndJewelry;
using MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Commands.UpdateWatchesAndJewelry;
using MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Queries.GetWatchesAndJewelryDetail;
using MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Queries.GetWatchesAndJewelryList;
using MarketMadeinSudan.Domin;
using MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Queries.GetAgriculturalCropsList;
using MarketMadeinSudan.Application.Features.FolderPublishers.Queries.GetPublishersDetail;
using MarketMadeinSudan.Application.Features.FolderPublishers.Commands.CreatePublishers;
using MarketMadeinSudan.Application.Features.FolderPublishers.Commands.UpdatePublishers;
using MarketMadeinSudan.Application.Features.FolderPublishers.Commands.DeletePublishers;
using MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.DeleteAdvertisements;
using MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.UpdateAdvertisements;
using MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.CreateAdvertisements;
using MarketMadeinSudan.Application.Features.FolderAdvertisements.Queries.GetAdvertisementsDetail;
using MarketMadeinSudan.Application.Features.FolderAdvertisements.Queries.GetAdvertisementsList;
using MarketMadeinSudan.Application.Features.FolderShipping.Commands.DeleteShipping;
using MarketMadeinSudan.Application.Features.FolderShipping.Commands.UpdateShipping;
using MarketMadeinSudan.Application.Features.FolderShipping.Commands.CreateShipping;
using MarketMadeinSudan.Application.Features.FolderShipping.Queries.GetShippingDetail;
using MarketMadeinSudan.Application.Features.FolderShipping.Queries.GetShippingList;

namespace MarketMadeinSudan.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Accessories, GetAccessoriesListViewModel>().ReverseMap();
            CreateMap<Accessories, GetAccessoriesDetailViewModel>().ReverseMap();
            CreateMap<Accessories, Features.FolderAccessories.Queries.GetAccessoriesList.CategoryDto>().ReverseMap();
            CreateMap<Accessories, CreateAccessoriesCommand>().ReverseMap();
            CreateMap<Accessories, UpdateAccessoriesCommand>().ReverseMap();
            CreateMap<Accessories, DeleteAccessoriesCommand>().ReverseMap();

            CreateMap<AgriculturalCrops, GetAgriculturalCropsListViewModel>().ReverseMap();
            CreateMap<AgriculturalCrops, GetAgriculturalCropsDetailViewModel>().ReverseMap();
            CreateMap<AgriculturalCrops, Features.FolderAgriculturalCrops.Queries.GetAgriculturalCropsList.CategoryDto>().ReverseMap();
            CreateMap<AgriculturalCrops, CreateAgriculturalCropsCommand>().ReverseMap();
            CreateMap<AgriculturalCrops, UpdateAgriculturalCropsCommand>().ReverseMap();
            CreateMap<AgriculturalCrops, DeleteAgriculturalCropsCommand>().ReverseMap();

            CreateMap<Aspires, GetAspiresListViewModel>().ReverseMap();
            CreateMap<Aspires, GetAspiresDetailViewModel>().ReverseMap();
            CreateMap<Aspires, Features.FolderAspires.Queries.GetAspiresList.CategoryDto>().ReverseMap();
            CreateMap<Aspires, CreateAspiresCommand>().ReverseMap();
            CreateMap<Aspires, UpdateAspiresCommand>().ReverseMap();
            CreateMap<Aspires, DeleteAspiresCommand>().ReverseMap();

            CreateMap<ElectricalAndElctronic, GetElectricalAndElctronicListViewModel>().ReverseMap();
            CreateMap<ElectricalAndElctronic, GetElectricalAndElctronicDetailViewModel>().ReverseMap();
            CreateMap<ElectricalAndElctronic, Features.FolderElectricalAndElctronic.Queries.GetElectricalAndElctronicList. CategoryDto>().ReverseMap();
            CreateMap<ElectricalAndElctronic, CreateElectricalAndElctronicCommand>().ReverseMap();
            CreateMap<ElectricalAndElctronic, UpdateElectricalAndElctronicCommand>().ReverseMap();
            CreateMap<ElectricalAndElctronic, DeleteElectricalAndElctronicCommand>().ReverseMap();

            CreateMap<Fabrics, GetFabricsListViewModel>().ReverseMap();
            CreateMap<Fabrics, GetFabricsDetailViewModel>().ReverseMap();
            CreateMap<Fabrics, Features.FolderFabrics.Queries.GetFabricsList. CategoryDto>().ReverseMap();
            CreateMap <Fabrics, CreateFabricsCommand>().ReverseMap();
            CreateMap<Fabrics, UpdateFabricsCommand>().ReverseMap();
            CreateMap<Fabrics, DeleteFabricsCommand>().ReverseMap();

            CreateMap<Food, GetFoodListViewModel>().ReverseMap();
            CreateMap<Food, GetFoodDetailViewModel>().ReverseMap();
            CreateMap<Food, Features.FolderFood.Queries.GetFoodList.CategoryDto>().ReverseMap();
            CreateMap<Food, CreateFoodCommand>().ReverseMap();
            CreateMap<Food, UpdateFoodCommand>().ReverseMap();
            CreateMap<Food, DeleteFoodCommand>().ReverseMap();

            CreateMap<HouseholdProducts, GetHouseholdProductsListViewModel>().ReverseMap();
            CreateMap<HouseholdProducts, GetHouseholdProductsDetailViewModel>().ReverseMap();
            CreateMap<HouseholdProducts, Features.FolderHouseholdProducts.Queries.GetHouseholdProductsList.CategoryDto>().ReverseMap();
            CreateMap<HouseholdProducts, CreateHouseholdProductsCommand>().ReverseMap();
            CreateMap<HouseholdProducts, UpdateHouseholdProductsCommand>().ReverseMap();
            CreateMap<HouseholdProducts, DeleteHouseholdProductsCommand>().ReverseMap();

            CreateMap<Other, GetOtherListViewModel>().ReverseMap();
            CreateMap<Other, GetOtherDetailViewModel>().ReverseMap();
            CreateMap<Other, Features.FolderOther.Queries.GetOtherList.CategoryDto>().ReverseMap();
            CreateMap<Other, CreateOtherCommand>().ReverseMap();
            CreateMap<Other, UpdateOtherCommand>().ReverseMap();
            CreateMap<Other, DeleteOtherCommand>().ReverseMap();

            CreateMap<SportAndEntertainment, GetSportAndEntertainmentListViewModel>().ReverseMap();
            CreateMap<SportAndEntertainment, GetSportAndEntertainmentDetailViewModel>().ReverseMap();
            CreateMap<SportAndEntertainment, Features.FolderSportAndEntertainment.Queries.GetSportAndEntertainmentList.CategoryDto>().ReverseMap();
            CreateMap<SportAndEntertainment, CreateSportAndEntertainmentCommand>().ReverseMap();
            CreateMap<SportAndEntertainment, UpdateSportAndEntertainmentCommand>().ReverseMap();
            CreateMap<SportAndEntertainment, DeleteSportAndEntertainmentCommand>().ReverseMap();

            CreateMap<WatchesAndJewelry, GetWatchesAndJewelryListViewModel>().ReverseMap();
            CreateMap<WatchesAndJewelry, GetWatchesAndJewelryDetailViewModel>().ReverseMap();
            CreateMap<WatchesAndJewelry, Features.FolderWatchesAndJewelry.Queries.GetWatchesAndJewelryList.CategoryDto>().ReverseMap();
            CreateMap<WatchesAndJewelry, CreateWatchesAndJewelryCommand>().ReverseMap();
            CreateMap<WatchesAndJewelry, UpdateWatchesAndJewelryCommand>().ReverseMap();
            CreateMap<WatchesAndJewelry, DeleteWatchesAndJewelryCommand>().ReverseMap();

            CreateMap<Publishers, GetPublishersListViewModel>().ReverseMap();
            CreateMap<Publishers, GetPublishersDetailViewModel>().ReverseMap();
            CreateMap<Publishers, Features.FolderPublishers.Queries.GetPublishersList.CategoryDto>().ReverseMap();
            CreateMap<Publishers, CreatePublishersCommand>().ReverseMap();
            CreateMap<Publishers, UpdatePublishersCommand>().ReverseMap();
            CreateMap<Publishers, DeletePublishersCommand>().ReverseMap();

            CreateMap<Cart, GetCartListViewModel>().ReverseMap();
            CreateMap<Cart, GetCartDetailViewModel>().ReverseMap();
            CreateMap<Cart, Features.FolderCart.Queries.GetCartList.CategoryDto>().ReverseMap();
            CreateMap<Cart, CreateCartCommand>().ReverseMap();
            CreateMap<Cart, UpdateCartCommand>().ReverseMap();
            CreateMap<Cart, DeleteCartCommand>().ReverseMap();

            CreateMap<OrderDetails, GetOrderDetailsListViewModel>().ReverseMap();
            CreateMap<OrderDetails, GetOrderDetailsDetailViewModel>().ReverseMap();
            CreateMap<OrderDetails, Features.FolderOrderDetails.Queries.GetOrderDetailsList.CategoryDto>().ReverseMap();
            CreateMap<OrderDetails, CreateOrderDetailsCommand>().ReverseMap();
            CreateMap<OrderDetails, UpdateOrderDetailsCommand>().ReverseMap();
            CreateMap<OrderDetails, DeleteOrderDetailsCommand>().ReverseMap();

            CreateMap<Advertisements, GetAdvertisementsListViewModel>().ReverseMap();
            CreateMap<Advertisements, GetAdvertisementsDetailViewModel>().ReverseMap();
            CreateMap<Advertisements, Features.FolderAdvertisements.Queries.GetAdvertisementsList.CategoryDto>().ReverseMap();
            CreateMap<Advertisements, CreateAdvertisementsCommand>().ReverseMap();
            CreateMap<Advertisements, UpdateAdvertisementsCommand>().ReverseMap();
            CreateMap<Advertisements, DeleteAdvertisementsCommand>().ReverseMap();

            CreateMap<Shipping, GetShippingListViewModel>().ReverseMap();
            CreateMap<Shipping, GetShippingDetailViewModel>().ReverseMap();
            CreateMap<Shipping, Features.FolderShipping.Queries.GetShippingList.CategoryDto>().ReverseMap();
            CreateMap<Shipping, CreateShippingCommand>().ReverseMap();
            CreateMap<Shipping, UpdateShippingCommand>().ReverseMap();
            CreateMap<Shipping, DeleteShippingCommand>().ReverseMap();

        }
    }
}
