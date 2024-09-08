using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Commands.CreateHouseholdProducts;
using MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Commands.UpdateHouseholdProducts;
using MarketMadeinSudan.Domin;
using MarketMadeinSudan.Persistence;
using MarketMadeinSudan.Persistence.Repositories;
using MarketMadeinSudan.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Media;
using System.Security.Claims;

namespace MarketMadeinSudan.UI.Controllers
{
    public class HouseholdProductsController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHouseholdProductsRepository _HouseholdProductsRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public HouseholdProductsController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            IHouseholdProductsRepository HouseholdProductsRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _HouseholdProductsRepository = HouseholdProductsRepository;
            _mapper = mapper;
            _hosting = hosting;
            _userManager = userManager;
            _authorizationService = authorizationService;
            this._con = con;
        }
        [Authorize]
        // GET: MarPicController
        public async Task<ActionResult> Index()
        {
            SetUser();
            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _HouseholdProductsRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _HouseholdProductsRepository.GetHouseholdProductsDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _HouseholdProductsRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var relatedProducts = await _con.HouseholdProductss
                .Where(p => p.HouseholdProductsName == model.HouseholdProductsName).ToListAsync();
            ViewData["RelatedProducts"] = relatedProducts;

            return View(model);
        }

        // GET: MarPicController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: MarPicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateHouseholdProductsCommand HouseholdProducts, List<IFormFile> Image)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                HouseholdProducts model = new HouseholdProducts
                {
                    PublishersId = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault(),
                    HouseholdProductsName = HouseholdProducts.HouseholdProductsName,
                    EmailCompany = HouseholdProducts.EmailCompany,
                    Description = HouseholdProducts.Description,
                    PhoneCompany = HouseholdProducts.PhoneCompany,
                    ImageUrl = HouseholdProducts.ImageUrl,
                    ImageProduct = HouseholdProducts.ImageProduct,
                    PictureProduct = HouseholdProducts.PictureProduct,
                    Quantity = HouseholdProducts.Quantity,
                    DateOfEstablishment = HouseholdProducts.DateOfEstablishment,
                    WebSite = HouseholdProducts.WebSite,
                    MeasruingUnit = HouseholdProducts.MeasruingUnit,
                    FounderAddress = HouseholdProducts.FounderAddress,
                    DescriptionCompany = HouseholdProducts.DescriptionCompany,
                    Pirce = HouseholdProducts.Pirce,
                    NameCompany = HouseholdProducts.NameCompany,
                    UserId = _userManager.GetUserAsync(User).Result.Id
                };
                if (Request.Form.Files.Count > 0)
                {
                    var files = Request.Form.Files;

                    //check file size and extension

                    using (var dataStream1 = new MemoryStream())
                    {
                        await files[0].CopyToAsync(dataStream1);
                        model.ImageUrl = dataStream1.ToArray();
                    }

                    using (var dataStream2 = new MemoryStream())
                    {
                        await files[1].CopyToAsync(dataStream2);
                        model.ImageProduct = dataStream2.ToArray();
                    }
                    using (var dataStream3 = new MemoryStream())
                    {
                        await files[2].CopyToAsync(dataStream3);
                        model.PictureProduct = dataStream3.ToArray();
                    }

                    await _HouseholdProductsRepository.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(HouseholdProducts);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _HouseholdProductsRepository.GetByIdAsync(id);
            UpdateHouseholdProductsCommand UpdateHouseholdProducts = new UpdateHouseholdProductsCommand
            {
                PublishersId = model.PublishersId,
                MeasruingUnit = model.MeasruingUnit,
                EmailCompany = model.EmailCompany,
                HouseholdProductsId = model.HouseholdProductsId,
                HouseholdProductsName = model.HouseholdProductsName,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                ImageProduct = model.ImageProduct,
                PictureProduct = model.PictureProduct,
                Quantity = model.Quantity,
                Pirce = model.Pirce,
                PhoneCompany = model.PhoneCompany,

                DateOfEstablishment = model.DateOfEstablishment,
                WebSite = model.WebSite,
                FounderAddress = model.FounderAddress,
                DescriptionCompany = model.DescriptionCompany,
                NameCompany = model.NameCompany,
                UserId = model.UserId
            };

            return View(UpdateHouseholdProducts);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateHouseholdProductsCommand updateHouseholdProductsCommand, List<IFormFile> Image)
        {
            try
            {
                var files = Request.Form.Files;

                if (files.Any())
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        var file = files[i];

                        using var dataStream = new MemoryStream();
                        await file.CopyToAsync(dataStream);

                        if (i == 0)
                        {
                            updateHouseholdProductsCommand.ImageUrl = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updateHouseholdProductsCommand.ImageProduct = dataStream.ToArray();
                        }
                        else if (i == 2)
                        {
                            updateHouseholdProductsCommand.PictureProduct = dataStream.ToArray();
                        }
                    }
                }
                HouseholdProducts UpdateHouseholdProducts = new HouseholdProducts
                {
                    EmailCompany = updateHouseholdProductsCommand.EmailCompany,
                    MeasruingUnit = updateHouseholdProductsCommand.MeasruingUnit,
                    PublishersId = updateHouseholdProductsCommand.PublishersId,
                    HouseholdProductsId = updateHouseholdProductsCommand.HouseholdProductsId,
                    HouseholdProductsName = updateHouseholdProductsCommand.HouseholdProductsName,
                    Description = updateHouseholdProductsCommand.Description,
                    ImageUrl = updateHouseholdProductsCommand.ImageUrl,
                    ImageProduct = updateHouseholdProductsCommand.ImageProduct,
                    PictureProduct = updateHouseholdProductsCommand.PictureProduct,
                    Quantity = updateHouseholdProductsCommand.Quantity,
                    PhoneCompany = updateHouseholdProductsCommand.PhoneCompany,
                    Pirce = updateHouseholdProductsCommand.Pirce,
                    DateOfEstablishment = updateHouseholdProductsCommand.DateOfEstablishment,
                    WebSite = updateHouseholdProductsCommand.WebSite,
                    FounderAddress = updateHouseholdProductsCommand.FounderAddress,
                    DescriptionCompany = updateHouseholdProductsCommand.DescriptionCompany,
                    NameCompany = updateHouseholdProductsCommand.NameCompany,
                    UserId = updateHouseholdProductsCommand.UserId
                };

                await _HouseholdProductsRepository.UpdateAsync(UpdateHouseholdProducts);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateHouseholdProductsCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid HouseholdProductsId)
        {
            try
            {

                var deleteHouseholdProductsCommand = new HouseholdProducts() { HouseholdProductsId = HouseholdProductsId };

                await _HouseholdProductsRepository.DeleteAsync(deleteHouseholdProductsCommand);
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
            var result = _HouseholdProductsRepository.Search().Where(a => a.HouseholdProductsName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id, HouseholdProducts model)
        {
            var HouseholdProducts = _con.HouseholdProductss.Find(id);
            if (HouseholdProducts == null) { return NotFound(); }
            if (model.Quantity > HouseholdProducts.Quantity) { return BadRequest("The quantity is not available"); }
            HouseholdProducts.Quantity -= 1;
            _con.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Minus(Guid id)
        {

            var HouseholdProducts = _con.HouseholdProductss.Find(id);
            if (HouseholdProducts == null) { return NotFound(); }
            HouseholdProducts.Quantity += 1;
            _con.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

