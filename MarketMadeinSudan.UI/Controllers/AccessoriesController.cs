using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderAccessories.Commands.CreateAccessories;
using MarketMadeinSudan.Application.Features.FolderAccessories.Commands.UpdateAccessories;
using MarketMadeinSudan.Domin;
using MarketMadeinSudan.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MarketMadeinSudan.UI.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccessoriesRepository _AccessoriesRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public AccessoriesController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            IAccessoriesRepository accessoriesRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _AccessoriesRepository = accessoriesRepository;
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
                var model = await _AccessoriesRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _AccessoriesRepository.GetAccessoriesDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _AccessoriesRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var relatedProducts = await _con.Accessoriess
                .Where(p=> p.AccessoriesName == model.AccessoriesName).ToListAsync();
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
        public async Task<ActionResult> Create(CreateAccessoriesCommand accessories, List<IFormFile> Image)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                Accessories model = new Accessories
                {
                    PublishersId = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault(),
                    AccessoriesName = accessories.AccessoriesName,
                    EmailCompany= accessories.EmailCompany,
                    Description = accessories.Description,
                    PhoneCompany = accessories.PhoneCompany,
                    ImageUrl = accessories.ImageUrl,
                    ImageProduct = accessories.ImageProduct,
                    PictureProduct = accessories.PictureProduct,
                    Quantity = accessories.Quantity,
                    DateOfEstablishment = accessories.DateOfEstablishment,
                    WebSite = accessories.WebSite,
                    MeasruingUnit = accessories.MeasruingUnit,
                    FounderAddress = accessories.FounderAddress,
                    DescriptionCompany = accessories.DescriptionCompany,
                    Pirce = accessories.Pirce,
                    NameCompany = accessories.NameCompany,
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

                    await _AccessoriesRepository.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(accessories);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _AccessoriesRepository.GetByIdAsync(id);
            UpdateAccessoriesCommand UpdateAccessories = new UpdateAccessoriesCommand
            {
                PublishersId = model.PublishersId,
                MeasruingUnit = model.MeasruingUnit,
                EmailCompany = model.EmailCompany,
                AccessoriesId = model.AccessoriesId,
                AccessoriesName = model.AccessoriesName,
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

            return View(UpdateAccessories);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateAccessoriesCommand updateAccessoriesCommand, List<IFormFile> Image)
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
                            updateAccessoriesCommand.ImageUrl = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updateAccessoriesCommand.ImageProduct = dataStream.ToArray();
                        }else if (i == 2)
                        {
                            updateAccessoriesCommand.PictureProduct = dataStream.ToArray();
                        }
                    }
                }
                Accessories UpdateAccessories = new Accessories
                {
                    EmailCompany = updateAccessoriesCommand.EmailCompany,
                    MeasruingUnit = updateAccessoriesCommand.MeasruingUnit,
                    PublishersId = updateAccessoriesCommand.PublishersId,
                    AccessoriesId = updateAccessoriesCommand.AccessoriesId,
                    AccessoriesName = updateAccessoriesCommand.AccessoriesName,
                    Description = updateAccessoriesCommand.Description,
                    ImageUrl = updateAccessoriesCommand.ImageUrl,
                    ImageProduct = updateAccessoriesCommand.ImageProduct,
                    PictureProduct = updateAccessoriesCommand.PictureProduct,
                    Quantity = updateAccessoriesCommand.Quantity,
                    PhoneCompany = updateAccessoriesCommand.PhoneCompany,
                    Pirce = updateAccessoriesCommand.Pirce,
                    DateOfEstablishment = updateAccessoriesCommand.DateOfEstablishment,
                    WebSite = updateAccessoriesCommand.WebSite,
                    FounderAddress = updateAccessoriesCommand.FounderAddress,
                    DescriptionCompany = updateAccessoriesCommand.DescriptionCompany,
                    NameCompany = updateAccessoriesCommand.NameCompany,
                    UserId = updateAccessoriesCommand.UserId
                };

                await _AccessoriesRepository.UpdateAsync(UpdateAccessories);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateAccessoriesCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid AccessoriesId)
        {
            try
            {

                var deleteAccessoriesCommand = new Accessories() { AccessoriesId = AccessoriesId };

                await _AccessoriesRepository.DeleteAsync(deleteAccessoriesCommand);
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
            var result = _AccessoriesRepository.Search().Where(a => a.AccessoriesName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id, Accessories model)
        {
            var accessories = _con.Accessoriess.Find(id);
            if (accessories == null) { return NotFound(); }
            if (model.Quantity > accessories.Quantity) { return BadRequest("The quantity is not available"); }
            accessories.Quantity -= 1;
            _con.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Minus(Guid id)
        {

            var accessories = _con.Accessoriess.Find(id);
            if (accessories == null) { return NotFound(); }
            accessories.Quantity += 1;
            _con.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

