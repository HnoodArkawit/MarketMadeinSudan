using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderCart.Commands.CreateCart;
using MarketMadeinSudan.Application.Features.FolderCart.Commands.UpdateCart;
using MarketMadeinSudan.Domin;
using MarketMadeinSudan.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace MarketMadeinSudan.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartRepository _CartRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public static int cartCount = 0;
        public CartController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            ICartRepository cartRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _CartRepository = cartRepository;
            _mapper = mapper;
            _hosting = hosting;
            _userManager = userManager;
            _authorizationService = authorizationService;
            cartCount = _CartRepository.GetAll().Count();
            _PublishersRepository = publishersRepository;
            this._con = con;
        }

        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCartCommand cart)
        {
            try
            {
                Cart model = new Cart
                {
                    MeasruingUnit = cart.MeasruingUnit,
                    PublishersId = cart.PublishersId,
                    PhoneCompany = cart.PhoneCompany,
                    AddressCompany = cart.AddressCompany,
                    NameCompany = cart.NameCompany,
                    EmailCompany = cart.EmailCompany,
                    ProductName = cart.ProductName,
                    Count = cart.Count,
                    Price = cart.Price,
                    UserId = _userManager.GetUserAsync(User).Result.Id
                };

                await _CartRepository.AddAsync(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return RedirectToAction(nameof(AllCart));
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateCartCommand updateCartCommand)
        {
            try
            {
                Cart UpdateCart = new Cart
                {
                    Count = updateCartCommand.Count,
                };

                await _CartRepository.UpdateAsync(UpdateCart);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateCartCommand);
        }

        public async Task<ActionResult> AllCart()
        {
            SetUser();
            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _CartRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _CartRepository.GetCartDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id)
        {

            var blog = _con.Carts.Find(id);
            if (blog == null) { return NotFound(); }
            blog.Count +=1;
            _con.SaveChanges();

            //var accessories = _con.Accessoriess.Find(id);
            //if (accessories == null) { return NotFound(); }
            //accessories.Quantity -= 1;
            //_con.SaveChanges();

            return RedirectToAction("AllCart", "Cart");
        }
        public IActionResult Minus(Guid id)
        {
            var blog = _con.Carts.Find(id);
            if (blog == null) { return NotFound(); }
            blog.Count -=1;
            _con.SaveChanges();

            //var accessories = _con.Accessoriess.Find(id);
            //if (accessories == null) { return NotFound(); }
            //accessories.Quantity += 1;
            //_con.SaveChanges();

            return RedirectToAction("AllCart", "Cart");
        }

    }
}
