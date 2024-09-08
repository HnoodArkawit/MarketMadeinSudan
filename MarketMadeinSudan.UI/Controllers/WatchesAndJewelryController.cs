using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Commands.CreateWatchesAndJewelry;
using MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Commands.UpdateWatchesAndJewelry;
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
    public class WatchesAndJewelryController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWatchesAndJewelryRepository _WatchesAndJewelryRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public WatchesAndJewelryController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            IWatchesAndJewelryRepository WatchesAndJewelryRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _WatchesAndJewelryRepository = WatchesAndJewelryRepository;
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
                var model = await _WatchesAndJewelryRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _WatchesAndJewelryRepository.GetWatchesAndJewelryDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _WatchesAndJewelryRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var relatedProducts = await _con.WatchesAndJewelrys
                .Where(p => p.WatchesAndJewelryName == model.WatchesAndJewelryName).ToListAsync();
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
        public async Task<ActionResult> Create(CreateWatchesAndJewelryCommand WatchesAndJewelry, List<IFormFile> Image)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                WatchesAndJewelry model = new WatchesAndJewelry
                {
                    PublishersId = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault(),
                    WatchesAndJewelryName = WatchesAndJewelry.WatchesAndJewelryName,
                    EmailCompany = WatchesAndJewelry.EmailCompany,
                    Description = WatchesAndJewelry.Description,
                    PhoneCompany = WatchesAndJewelry.PhoneCompany,
                    ImageUrl = WatchesAndJewelry.ImageUrl,
                    ImageProduct = WatchesAndJewelry.ImageProduct,
                    PictureProduct = WatchesAndJewelry.PictureProduct,
                    Quantity = WatchesAndJewelry.Quantity,
                    DateOfEstablishment = WatchesAndJewelry.DateOfEstablishment,
                    WebSite = WatchesAndJewelry.WebSite,
                    MeasruingUnit = WatchesAndJewelry.MeasruingUnit,
                    FounderAddress = WatchesAndJewelry.FounderAddress,
                    DescriptionCompany = WatchesAndJewelry.DescriptionCompany,
                    Pirce = WatchesAndJewelry.Pirce,
                    NameCompany = WatchesAndJewelry.NameCompany,
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

                    await _WatchesAndJewelryRepository.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(WatchesAndJewelry);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _WatchesAndJewelryRepository.GetByIdAsync(id);
            UpdateWatchesAndJewelryCommand UpdateWatchesAndJewelry = new UpdateWatchesAndJewelryCommand
            {
                PublishersId = model.PublishersId,
                MeasruingUnit = model.MeasruingUnit,
                EmailCompany = model.EmailCompany,
                WatchesAndJewelryId = model.WatchesAndJewelryId,
                WatchesAndJewelryName = model.WatchesAndJewelryName,
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

            return View(UpdateWatchesAndJewelry);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateWatchesAndJewelryCommand updateWatchesAndJewelryCommand, List<IFormFile> Image)
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
                            updateWatchesAndJewelryCommand.ImageUrl = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updateWatchesAndJewelryCommand.ImageProduct = dataStream.ToArray();
                        }
                        else if (i == 2)
                        {
                            updateWatchesAndJewelryCommand.PictureProduct = dataStream.ToArray();
                        }
                    }
                }
                WatchesAndJewelry UpdateWatchesAndJewelry = new WatchesAndJewelry
                {
                    EmailCompany = updateWatchesAndJewelryCommand.EmailCompany,
                    MeasruingUnit = updateWatchesAndJewelryCommand.MeasruingUnit,
                    PublishersId = updateWatchesAndJewelryCommand.PublishersId,
                    WatchesAndJewelryId = updateWatchesAndJewelryCommand.WatchesAndJewelryId,
                    WatchesAndJewelryName = updateWatchesAndJewelryCommand.WatchesAndJewelryName,
                    Description = updateWatchesAndJewelryCommand.Description,
                    ImageUrl = updateWatchesAndJewelryCommand.ImageUrl,
                    ImageProduct = updateWatchesAndJewelryCommand.ImageProduct,
                    PictureProduct = updateWatchesAndJewelryCommand.PictureProduct,
                    Quantity = updateWatchesAndJewelryCommand.Quantity,
                    PhoneCompany = updateWatchesAndJewelryCommand.PhoneCompany,
                    Pirce = updateWatchesAndJewelryCommand.Pirce,
                    DateOfEstablishment = updateWatchesAndJewelryCommand.DateOfEstablishment,
                    WebSite = updateWatchesAndJewelryCommand.WebSite,
                    FounderAddress = updateWatchesAndJewelryCommand.FounderAddress,
                    DescriptionCompany = updateWatchesAndJewelryCommand.DescriptionCompany,
                    NameCompany = updateWatchesAndJewelryCommand.NameCompany,
                    UserId = updateWatchesAndJewelryCommand.UserId
                };

                await _WatchesAndJewelryRepository.UpdateAsync(UpdateWatchesAndJewelry);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateWatchesAndJewelryCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid WatchesAndJewelryId)
        {
            try
            {

                var deleteWatchesAndJewelryCommand = new WatchesAndJewelry() { WatchesAndJewelryId = WatchesAndJewelryId };

                await _WatchesAndJewelryRepository.DeleteAsync(deleteWatchesAndJewelryCommand);
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
            var result = _WatchesAndJewelryRepository.Search().Where(a => a.WatchesAndJewelryName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id, WatchesAndJewelry model)
        {
            var WatchesAndJewelry = _con.WatchesAndJewelrys.Find(id);
            if (WatchesAndJewelry == null) { return NotFound(); }
            if (model.Quantity > WatchesAndJewelry.Quantity) { return BadRequest("The quantity is not available"); }
            WatchesAndJewelry.Quantity -= 1;
            _con.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Minus(Guid id)
        {

            var WatchesAndJewelry = _con.WatchesAndJewelrys.Find(id);
            if (WatchesAndJewelry == null) { return NotFound(); }
            WatchesAndJewelry.Quantity += 1;
            _con.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

