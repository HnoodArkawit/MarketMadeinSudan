using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MarketMadeinSudan.Application.Features.FolderShipping.Commands.CreateShipping;
using MarketMadeinSudan.Domin;
using System.Security.Claims;
using MarketMadeinSudan.Application.Features.FolderShipping.Commands.UpdateShipping;
using MarketMadeinSudan.UI.Models;
using Microsoft.EntityFrameworkCore;
using MarketMadeinSudan.Persistence.Repositories;

namespace MarketMadeinSudan.UI.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IOrderDetailsRepository _OrderDetailsVMService;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IShippingRepository _ShippingRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private Task<AuthorizationResult> result;
        private string UserId;
        public ShippingController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,
            IAuthorizationService authorizationService, IShippingRepository shippingRepository, 
            IOrderDetailsRepository OrderDetailsVMService, IMapper mapper, IPublishersRepository publishersRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authorizationService = authorizationService;
            _ShippingRepository = shippingRepository;
            _PublishersRepository = publishersRepository;
            _OrderDetailsVMService = OrderDetailsVMService;
            _roleManager = roleManager;
        }

        // GET: ShippingController
        public async Task<ActionResult> Index(string Search)
        {
            SetUser();
            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _ShippingRepository.ListAllAsync();
                return View(model);
            }
            else
            {

                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var PublishersName = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault();
                var model = new object();
                if (!string.IsNullOrEmpty(Search))
                {
                    model = _ShippingRepository.GetAll().Where(x => x.PublishersId == PublishersName).Where(x => x.Status.Contains(Search) || x.firstNameCustoer.ToString().Contains(Search)).ToList();
                }
                else
                {
                    model = _ShippingRepository.GetAll().Where(x => x.PublishersId == PublishersName);
                }
                return View(model);

            }
        }
        public async Task<ActionResult> IndexCompany(string Search)
        {
            SetUser();
            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _ShippingRepository.ListAllAsync();
                return View(model);
            }
            else
            {

                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var PublishersName = _ShippingRepository.GetOrderDetailsDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.OrderDetailsId).FirstOrDefault();
                var model = new object();
                if (!string.IsNullOrEmpty(Search))
                {
                    model = _ShippingRepository.GetShippingDataByUser(UserId).Where(x => x.UserId == UserId).Where(x => x.firstNameCustoer.Contains(Search) || x.Status.Contains(Search)).ToList();
                }
                else
                {
                    model = _ShippingRepository.GetShippingDataByUser(UserId).Where(x => x.UserId == UserId);
                }
                return View(model);
            }
        }

        // GET: ShippingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShippingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateShippingCommand shipping)
        {
            try
            {
                Shipping model = new Shipping
                {
                    PublishersId = shipping.PublishersId,
                    NameCompany = shipping.NameCompany,
                    AddressShipping = shipping.AddressShipping,
                    EmailShipping = shipping.EmailShipping,
                    Status = shipping.Status,
                    PhoneShipping = shipping.PhoneShipping,
                    DescriptionShipping = shipping.DescriptionShipping,
                    firstNameCustoer = shipping.firstNameCustoer,
                    Count = shipping.Count,
                    AddressCustoer = shipping.AddressCustoer,
                    EmailCustoer = shipping.EmailCustoer,
                    PhoneCustomer = shipping.PhoneCustomer,
                    ProductName = shipping.ProductName,
                    CountryCustoer = shipping.CountryCustoer,
                    NameShipping = shipping.NameShipping,
                    EmailCompany = shipping.EmailCompany,
                    AddressCompany = shipping.AddressCompany,
                    PhoneCompany = shipping.PhoneCompany,
                    UserId = _userManager.GetUserAsync(User).Result.Id
                };
                await _ShippingRepository.AddAsync(model);
                TempData["success"] = "تم ارسال الطلب بنجاح";

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("IndexCompany", "Shipping");

            //return Redirect(Request.Headers["Referer"].ToString());
        }


        // GET: ShippingController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _ShippingRepository.GetByIdAsync(id);
            UpdateShippingCommand UpdateShipping = new UpdateShippingCommand
            {
                PublishersId = model.PublishersId,
                ShippingId = model.ShippingId,
                NameCompany = model.NameCompany,
                AddressShipping = model.AddressShipping,
                EmailShipping = model.EmailShipping,
                PhoneShipping = model.PhoneShipping,
                DescriptionShipping = model.DescriptionShipping,
                firstNameCustoer = model.firstNameCustoer,
                Count = model.Count,
                Status = model.Status,
                AddressCustoer = model.AddressCustoer,
                EmailCustoer = model.EmailCustoer,
                PhoneCustomer = model.PhoneCustomer,
                ProductName = model.ProductName,
                CountryCustoer = model.CountryCustoer,
                NameShipping = model.NameShipping,
                EmailCompany = model.EmailCompany,
                AddressCompany = model.AddressCompany,
                PhoneCompany = model.PhoneCompany,
                UserId = model.UserId
            };

            return View(UpdateShipping);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(Guid id, UpdateShippingCommand updateShippingCommand)
        {
            try
            {
                Shipping UpdateShipping = new Shipping
                {
                    PublishersId = updateShippingCommand.PublishersId,
                    ShippingId = updateShippingCommand.ShippingId,
                    NameCompany = updateShippingCommand.NameCompany,
                    AddressShipping = updateShippingCommand.AddressShipping,
                    EmailShipping = updateShippingCommand.EmailShipping,
                    PhoneShipping = updateShippingCommand.PhoneShipping,
                    DescriptionShipping = updateShippingCommand.DescriptionShipping,
                    Status = updateShippingCommand.Status,
                    firstNameCustoer = updateShippingCommand.firstNameCustoer,
                    Count = updateShippingCommand.Count,
                    AddressCustoer = updateShippingCommand.AddressCustoer,
                    EmailCustoer = updateShippingCommand.EmailCustoer,
                    PhoneCustomer = updateShippingCommand.PhoneCustomer,
                    ProductName = updateShippingCommand.ProductName,
                    CountryCustoer = updateShippingCommand.CountryCustoer,
                    NameShipping = updateShippingCommand.NameShipping,
                    EmailCompany = updateShippingCommand.EmailCompany,
                    AddressCompany = updateShippingCommand.AddressCompany,
                    PhoneCompany = updateShippingCommand.PhoneCompany,
                    UserId = updateShippingCommand.UserId
                };

                await _ShippingRepository.UpdateAsync(UpdateShipping);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateShippingCommand);
        }


        // GET: ShippingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShippingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid ShippingId)
        {
            try
            {

                var deleteShippingCommand = new Shipping() { ShippingId = ShippingId };

                await _ShippingRepository.DeleteAsync(deleteShippingCommand);
                TempData["success"] = " تمت عملية الحذف بنجاح ";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public async Task<ActionResult> ChooseOne(string Search)
        {

            SetUser();
            if (User.IsInRole("Admin"))
            {
                var shippingRole = await _roleManager.Roles.Where(x => x.Name == "Shipping").FirstOrDefaultAsync();
                var usersInShippingRole = await _userManager.GetUsersInRoleAsync(shippingRole.Name);
                var publishersInShippingGroup = _PublishersRepository.GetAll().Where(p => usersInShippingRole.Any(u => u.Id == p.UserId)).ToList();

                var model = new ShippingPublishersViewModel
                {
                    Publishers = publishersInShippingGroup,
                    OrderDetails = await _OrderDetailsVMService.ListAllAsync()
                };

                return View(model);
            }
            else
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var PublishersName = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault();
                var model = new object();
                if (!string.IsNullOrEmpty(Search))
                {

                    var shippingRole = await _roleManager.Roles.Where(x => x.Name == "Shipping").FirstOrDefaultAsync();
                    var usersInShippingRole = await _userManager.GetUsersInRoleAsync(shippingRole.Name);
                    var publishersInShippingGroup = _PublishersRepository.GetAll().Where(p => usersInShippingRole.Any(u => u.Id == p.UserId)).Where(x => x.NameCompany.Contains(Search) || x.PublishersId.ToString().Contains(Search)).ToList();

                    model = new ShippingPublishersViewModel
                    {
                        Publishers = publishersInShippingGroup,
                        OrderDetails = _OrderDetailsVMService.GetOrderDetailsDataByUser(UserId).Where(x => x.UserId == UserId)
                    };
                    return View(model);

                }
                else
                {
                    var shippingRole = await _roleManager.Roles.Where(x => x.Name == "Shipping").FirstOrDefaultAsync();
                    var usersInShippingRole = await _userManager.GetUsersInRoleAsync(shippingRole.Name);
                    var publishersInShippingGroup = _PublishersRepository.GetAll().Where(p => usersInShippingRole.Any(u => u.Id == p.UserId)).ToList();
                    var PublishersNamea = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault();

                    model = new ShippingPublishersViewModel
                    {
                        Publishers = publishersInShippingGroup,
                        OrderDetails = _OrderDetailsVMService.GetAll().Where(x => x.PublishersId == PublishersNamea)
                };
                    return View(model);

                }

            }
        }


    }
}
