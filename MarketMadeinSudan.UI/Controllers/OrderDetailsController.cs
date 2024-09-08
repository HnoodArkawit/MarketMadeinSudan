using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.CreateOrderDetails;
using MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.UpdateOrderDetails;
using MarketMadeinSudan.Domin;
using MarketMadeinSudan.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Data;
using System.Security.Claims;

namespace MarketMadeinSudan.UI.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IPublishersRepository _PublishersRepository;
        private readonly ICartRepository _CartRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderDetailsRepository _OrderDetailsVMService;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        private readonly MarketMadeinSudanDbContext _con;

        public OrderDetailsController(UserManager<ApplicationUser> userManager, MarketMadeinSudanDbContext con,
            IAuthorizationService authorizationService, ICartRepository cartRepository,
            IOrderDetailsRepository OrderDetailsVMService, IMapper mapper, IPublishersRepository publishersRepository,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _CartRepository = cartRepository;
            _OrderDetailsVMService = OrderDetailsVMService;
            _mapper = mapper;
            _hosting = hosting; this._con = con;
            _userManager = userManager;
            _authorizationService = authorizationService;

        }

        // GET: OrderDetailsController
        public async Task<ActionResult> Index(string Search)
        {
            SetUser();
            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _OrderDetailsVMService.ListAllAsync();
                return View(model);
            }
            else
            {

                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var PublishersName = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault();
                var model = new object();
                if (!string.IsNullOrEmpty(Search))
                {
                    model = _OrderDetailsVMService.GetAll().Where(x => x.PublishersId == PublishersName).Where(x => x.Status.Contains(Search) || x.OrderDetailsId.ToString().Contains(Search)).ToList();
                }
                else
                {
                    model = _OrderDetailsVMService.GetAll().Where(x => x.PublishersId == PublishersName);
                }
                return View(model);

            }
        }

        public async Task<ActionResult> IndexCustomer(string Search)
        {
            SetUser();
            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _OrderDetailsVMService.ListAllAsync();
                return View(model);
            }
            else
            {

                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var PublishersName = _OrderDetailsVMService.GetOrderDetailsDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.OrderDetailsId).FirstOrDefault();
                var model = new object();
                if (!string.IsNullOrEmpty(Search))
                {
                    model = _OrderDetailsVMService.GetOrderDetailsDataByUser(UserId).Where(x => x.UserId == UserId).Where(x => x.ProductName.Contains(Search) || x.OrderDetailsId.ToString().Contains(Search)).ToList();
                }
                else
                {
                    model = _OrderDetailsVMService.GetOrderDetailsDataByUser(UserId).Where(x => x.UserId == UserId);
                }
                return View(model);
            }
        }

        // GET: OrderDetailsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _OrderDetailsVMService.GetByIdAsync(id);
            return View(model);
        }

        // GET: OrderDetailsController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: OrderDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateOrderDetailsCommand OrderDetailsVM, Guid ProductId)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var cartList = _CartRepository.GetCartDataByUser(UserId).Where(x => x.UserId == UserId);
                foreach (var item in cartList)
                {
                    var model = new OrderDetails
                    {
                        PublishersId= item.PublishersId,
                        MeasruingUnit = item.MeasruingUnit,
                        ProductName = item.ProductName,
                        Price = item.Price,
                        Count = item.Count,
                        PhoneCompany = item.PhoneCompany,
                        AddressCompany = item.AddressCompany,
                        NameCompany = item.NameCompany,
                        EmailCompany = item.EmailCompany,
                        Total = OrderDetailsVM.Total,
                        firstName = OrderDetailsVM.firstName,
                        Status = OrderDetailsVM.Status,
                        lastName = OrderDetailsVM.lastName,
                        UserName = OrderDetailsVM.UserName,
                        Address = OrderDetailsVM.Address,
                        Phone = OrderDetailsVM.Phone,
                        Country = OrderDetailsVM.Country,
                        Zip = OrderDetailsVM.Zip,
                        DatePay = DateTime.Now,
                        Email = OrderDetailsVM.Email,
                        UserId = _userManager.GetUserAsync(User).Result.Id
                    };
                    await _OrderDetailsVMService.AddAsync(model);

                    var deleteCartCommand = new Cart() { UserId = UserId };
                    var cartsToDelete = _con.Carts.Where(c => c.UserId == deleteCartCommand.UserId);
                    _con.Carts.RemoveRange(cartsToDelete);
                    await _con.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: OrderDetailsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _OrderDetailsVMService.GetByIdAsync(id);
            UpdateOrderDetailsCommand UpdateOrderDetails = new UpdateOrderDetailsCommand
            {
                PhoneCompany = model.PhoneCompany,
                AddressCompany = model.AddressCompany,
                MeasruingUnit = model.MeasruingUnit,
                PublishersId = model.PublishersId,
                NameCompany = model.NameCompany,
                EmailCompany = model.EmailCompany,
                OrderDetailsId = model.OrderDetailsId,
                Total= model.Total,
                ProductName = model.ProductName,
                Price = model.Price,
                Count = model.Count,
                Status = model.Status,
                firstName = model.firstName,
                lastName = model.lastName,
                Phone = model.Phone,
                UserName = model.UserName,
                Address = model.Address,
                Country = model.Country,
                Zip = model.Zip,
                DatePay = model.DatePay,
                Email = model.Email,
                UserId = model.UserId
            };

            return View(UpdateOrderDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateOrderDetailsCommand updateOrderDetailsCommand)
        {
            try
            {
                    OrderDetails UpdateOrderDetails = new OrderDetails
                    {
                        PhoneCompany = updateOrderDetailsCommand.PhoneCompany,
                        AddressCompany = updateOrderDetailsCommand.AddressCompany,
                        MeasruingUnit = updateOrderDetailsCommand.MeasruingUnit,
                        Status = updateOrderDetailsCommand.Status,
                        PublishersId = updateOrderDetailsCommand.PublishersId,
                        NameCompany = updateOrderDetailsCommand.NameCompany,
                        EmailCompany = updateOrderDetailsCommand.EmailCompany,
                        OrderDetailsId = updateOrderDetailsCommand.OrderDetailsId,
                        ProductName = updateOrderDetailsCommand.ProductName,
                        Total= updateOrderDetailsCommand.Total,
                        Price = updateOrderDetailsCommand.Price,
                        Count = updateOrderDetailsCommand.Count,
                        firstName = updateOrderDetailsCommand.firstName,
                        lastName = updateOrderDetailsCommand.lastName,
                        UserName = updateOrderDetailsCommand.UserName,
                        Phone = updateOrderDetailsCommand.Phone,
                        Address = updateOrderDetailsCommand.Address,
                        Country = updateOrderDetailsCommand.Country,
                        Zip = updateOrderDetailsCommand.Zip,
                        DatePay = updateOrderDetailsCommand.DatePay,
                        Email = updateOrderDetailsCommand.Email,
                        UserId = updateOrderDetailsCommand.UserId
                    };

                    await _OrderDetailsVMService.UpdateAsync(UpdateOrderDetails);
                TempData["success"] = " تم تعديل  بنجاح    ";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateOrderDetailsCommand);
        }

        // POST: OrderDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid OrderDetailsId)
        {
            try
            {

                var deleteOrderDetailsCommand = new OrderDetails() { OrderDetailsId = OrderDetailsId };

                await _OrderDetailsVMService.DeleteAsync(deleteOrderDetailsCommand);
                TempData["success"] = " تمت عملية الحذف بنجاح ";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }
        public IActionResult Search(string ShearchName)
        {
            var result = _OrderDetailsVMService.Search().Where(a => a.Status.Contains(ShearchName)).ToList();
            return View("Index", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

    }
}
