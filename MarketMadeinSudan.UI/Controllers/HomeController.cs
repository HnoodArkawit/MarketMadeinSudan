using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MarketMadeinSudan.Persistence;
using MarketMadeinSudan.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketMadeinSudan.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPublishersRepository _PublishersRepository;
        private readonly ICartRepository _CartRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MarketMadeinSudanDbContext _con;
        private readonly ILogger<HomeController> _logger;
        private readonly IAccessoriesRepository _AccessoriesRepository;
        private readonly IAgriculturalCropsRepository _AgriculturalCropsRepository;
        private readonly IAspiresRepository _AspiresRepository;
        private readonly IElectricalAndElctronicRepository _ElectricalAndElctronicRepository;
        private readonly IFabricsRepository _FabricsRepository;
        private readonly IFoodRepository _FoodRepository;
        private readonly IHouseholdProductsRepository _HouseholdProductsRepository;
        private readonly ISportAndEntertainmentRepository _SportAndEntertainmentRepository;
        private readonly IWatchesAndJewelryRepository _WatchesAndJewelryRepository;
        private readonly IOtherRepository _OtherRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private readonly IAdvertisementsRepository _AdvertisementsService;
        private readonly IShippingRepository _ShippingRepository;
        private readonly IOrderDetailsRepository _OrderDetailsVMService;

        public HomeController(MarketMadeinSudanDbContext con, IAccessoriesRepository AccessoriesRepository, IAgriculturalCropsRepository AgriculturalCropsRepository, IAspiresRepository AspiresRepository,
            IFabricsRepository FabricsRepository, UserManager<ApplicationUser> userManager, IPublishersRepository publishersRepository, IOrderDetailsRepository OrderDetailsVMService,
             ICartRepository cartRepository, IAdvertisementsRepository AdvertisementsService, IShippingRepository shippingRepository,
            IOtherRepository OtherRepository , IFoodRepository FoodRepository, IHouseholdProductsRepository HouseholdProductsRepository,
            ISportAndEntertainmentRepository SportAndEntertainmentRepository, IWatchesAndJewelryRepository WatchesAndJewelryRepository, IElectricalAndElctronicRepository ElectricalAndElctronicRepository, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting, ILogger<HomeController> logger)
        {
            _logger = logger;
            this._AccessoriesRepository = AccessoriesRepository;
            this._mapper = mapper;
            _hosting = hosting;
            _PublishersRepository = publishersRepository;
            this._AgriculturalCropsRepository = AgriculturalCropsRepository;
            this._AspiresRepository = AspiresRepository;
            this._ElectricalAndElctronicRepository = ElectricalAndElctronicRepository;
            this._FabricsRepository = FabricsRepository;
            this._FoodRepository = FoodRepository;
            this._HouseholdProductsRepository = HouseholdProductsRepository;
            this._SportAndEntertainmentRepository = SportAndEntertainmentRepository;
            this._WatchesAndJewelryRepository = WatchesAndJewelryRepository;
            this._OtherRepository = OtherRepository;
            this._con = con;
            this._userManager = userManager;
            this._CartRepository = cartRepository;
            this._AdvertisementsService = AdvertisementsService;
            this._ShippingRepository = shippingRepository;
            _OrderDetailsVMService = OrderDetailsVMService;

        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Accessories = _AccessoriesRepository.GetAll().ToList(),
                AgriculturalCrops = _AgriculturalCropsRepository.GetAll().ToList(),
                Aspires = _AspiresRepository.GetAll().ToList(),
                ElectricalAndElctronic = _ElectricalAndElctronicRepository.GetAll().ToList(),
                Fabrics = _FabricsRepository.GetAll().ToList(),
                Food = _FoodRepository.GetAll().ToList(),
                HouseholdProducts = _HouseholdProductsRepository.GetAll().ToList(),
                SportAndEntertainment = _SportAndEntertainmentRepository.GetAll().ToList(),
                WatchesAndJewelry = _WatchesAndJewelryRepository.GetAll().ToList(),
                Other = _OtherRepository.GetAll().ToList(),
                Advertisementss = _AdvertisementsService.GetAll().ToList(),
                Publisherss = _PublishersRepository.GetAll().ToList(),
                Shipping = _ShippingRepository.GetAll().ToList(),
               OrderDetails = _OrderDetailsVMService.GetAll().ToList(),
            };

            return View(homeViewModel);
        }
        public IActionResult IndexAccessories()
        {
            var ViewAccessories = new HomeViewModel
            {
                Accessories = _AccessoriesRepository.GetAll().ToList(),
            };
            return View(ViewAccessories);
        }
        public IActionResult IndexAgriculturalCrops()
        {
            var ViewAgriculturalCrops = new HomeViewModel
            {
                AgriculturalCrops = _AgriculturalCropsRepository.GetAll().ToList(),
            };

            return View(ViewAgriculturalCrops);
        }
        public IActionResult IndexAspires()
        {
            var ViewAspires = new HomeViewModel
            {
                Aspires = _AspiresRepository.GetAll().ToList(),
            };

            return View(ViewAspires);
        }
        public IActionResult IndexElectricalAndElctronic()
        {
            var ViewElectricalAndElctronic = new HomeViewModel
            {
                ElectricalAndElctronic = _ElectricalAndElctronicRepository.GetAll().ToList(),
            };

            return View(ViewElectricalAndElctronic);
        }
        public IActionResult IndexFabrics()
        {
            var ViewFabrics = new HomeViewModel
            {
                Fabrics = _FabricsRepository.GetAll().ToList(),
            };

            return View(ViewFabrics);
        }
        public IActionResult IndexFood()
        {
            var ViewFood = new HomeViewModel
            {
                Food = _FoodRepository.GetAll().ToList(),
            };

            return View(ViewFood);
        }
        public IActionResult IndexHouseholdProducts()
        {
            var ViewHouseholdProducts = new HomeViewModel
            {
                HouseholdProducts = _HouseholdProductsRepository.GetAll().ToList(),
            };

            return View(ViewHouseholdProducts);
        }
        public IActionResult IndexSportAndEntertainment()
        {
            var ViewSportAndEntertainment = new HomeViewModel
            {
                SportAndEntertainment = _SportAndEntertainmentRepository.GetAll().ToList(),
            };

            return View(ViewSportAndEntertainment);
        }
        public IActionResult IndexWatchesAndJewelry()
        {
            var ViewWatchesAndJewelry = new HomeViewModel
            {
                WatchesAndJewelry = _WatchesAndJewelryRepository.GetAll().ToList(),
            };

            return View(ViewWatchesAndJewelry);
        }
        public IActionResult IndexOther()
        {
            var ViewOther = new HomeViewModel
            {
                Other = _OtherRepository.GetAll().ToList(),
            };

            return View(ViewOther);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public async Task<ActionResult> DetailAccessories(Guid id)
        {
            var model = await _AccessoriesRepository.GetByIdAsync(id);
            return View(model);
        }
        [Authorize]
        public async Task<ActionResult> DetailAgriculturalCrops(Guid id)
        {
            var model = await _AgriculturalCropsRepository.GetByIdAsync(id);
            return View(model);
        }
        [Authorize]
        public async Task<ActionResult> DetailAspires(Guid id)
        {
            var model = await _AspiresRepository.GetByIdAsync(id);
            return View(model);
        }
        [Authorize]
        public async Task<ActionResult> DetailsElectricalAndElctronic(Guid id)
        {
            var model = await _ElectricalAndElctronicRepository.GetByIdAsync(id);
            return View(model);
        }
        [Authorize]
        public async Task<ActionResult> DetailsFabrics(Guid id)
        {
            var model = await _FabricsRepository.GetByIdAsync(id);
            return View(model);
        }
        [Authorize]
        public async Task<ActionResult> DetailsFood(Guid id)
        {
            var model = await _FoodRepository.GetByIdAsync(id);
            return View(model);
        }
        [Authorize]
        public async Task<ActionResult> DetailsHouseholdProducts(Guid id)
        {
            var model = await _HouseholdProductsRepository.GetByIdAsync(id);
            return View(model);
        }
        [Authorize]
        public async Task<ActionResult> DetailsSportAndEntertainment(Guid id)
        {
            var model = await _SportAndEntertainmentRepository.GetByIdAsync(id);
            return View(model);
        }
        [Authorize]
        public async Task<ActionResult> DetailsWatchesAndJewelry(Guid id)
        {
            var model = await _WatchesAndJewelryRepository.GetByIdAsync(id);
            return View(model);
        }
        [Authorize]
        public async Task<ActionResult> DetailsOther(Guid id)
        {
            var model = await _OtherRepository.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid ProductId)
        {
            try
            {
                var deleteCartCommand = new Cart() { ProductId = ProductId };

                _con.Carts.Remove(deleteCartCommand);
                await _con.SaveChangesAsync();
                TempData["success"] = " تمت عملية الحذف بنجاح ";

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}