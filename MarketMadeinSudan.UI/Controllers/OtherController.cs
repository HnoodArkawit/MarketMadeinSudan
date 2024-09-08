using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderOther.Commands.CreateOther;
using MarketMadeinSudan.Application.Features.FolderOther.Commands.UpdateOther;
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
    public class OtherController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOtherRepository _OtherRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public OtherController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            IOtherRepository OtherRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _OtherRepository = OtherRepository;
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
                var model = await _OtherRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _OtherRepository.GetOtherDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _OtherRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var relatedProducts = await _con.Others
                .Where(p => p.OtherName == model.OtherName).ToListAsync();
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
        public async Task<ActionResult> Create(CreateOtherCommand Other, List<IFormFile> Image)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                Other model = new Other
                {
                    PublishersId = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault(),
                    OtherName = Other.OtherName,
                    EmailCompany = Other.EmailCompany,
                    Description = Other.Description,
                    PhoneCompany = Other.PhoneCompany,
                    ImageUrl = Other.ImageUrl,
                    ImageProduct = Other.ImageProduct,
                    PictureProduct = Other.PictureProduct,
                    Quantity = Other.Quantity,
                    DateOfEstablishment = Other.DateOfEstablishment,
                    WebSite = Other.WebSite,
                    MeasruingUnit = Other.MeasruingUnit,
                    FounderAddress = Other.FounderAddress,
                    DescriptionCompany = Other.DescriptionCompany,
                    Pirce = Other.Pirce,
                    NameCompany = Other.NameCompany,
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

                    await _OtherRepository.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(Other);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _OtherRepository.GetByIdAsync(id);
            UpdateOtherCommand UpdateOther = new UpdateOtherCommand
            {
                PublishersId = model.PublishersId,
                MeasruingUnit = model.MeasruingUnit,
                EmailCompany = model.EmailCompany,
                OtherId = model.OtherId,
                OtherName = model.OtherName,
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

            return View(UpdateOther);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateOtherCommand updateOtherCommand, List<IFormFile> Image)
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
                            updateOtherCommand.ImageUrl = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updateOtherCommand.ImageProduct = dataStream.ToArray();
                        }
                        else if (i == 2)
                        {
                            updateOtherCommand.PictureProduct = dataStream.ToArray();
                        }
                    }
                }
                Other UpdateOther = new Other
                {
                    EmailCompany = updateOtherCommand.EmailCompany,
                    MeasruingUnit = updateOtherCommand.MeasruingUnit,
                    PublishersId = updateOtherCommand.PublishersId,
                    OtherId = updateOtherCommand.OtherId,
                    OtherName = updateOtherCommand.OtherName,
                    Description = updateOtherCommand.Description,
                    ImageUrl = updateOtherCommand.ImageUrl,
                    ImageProduct = updateOtherCommand.ImageProduct,
                    PictureProduct = updateOtherCommand.PictureProduct,
                    Quantity = updateOtherCommand.Quantity,
                    PhoneCompany = updateOtherCommand.PhoneCompany,
                    Pirce = updateOtherCommand.Pirce,
                    DateOfEstablishment = updateOtherCommand.DateOfEstablishment,
                    WebSite = updateOtherCommand.WebSite,
                    FounderAddress = updateOtherCommand.FounderAddress,
                    DescriptionCompany = updateOtherCommand.DescriptionCompany,
                    NameCompany = updateOtherCommand.NameCompany,
                    UserId = updateOtherCommand.UserId
                };

                await _OtherRepository.UpdateAsync(UpdateOther);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateOtherCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid OtherId)
        {
            try
            {

                var deleteOtherCommand = new Other() { OtherId = OtherId };

                await _OtherRepository.DeleteAsync(deleteOtherCommand);
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
            var result = _OtherRepository.Search().Where(a => a.OtherName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id, Other model)
        {
            var Other = _con.Others.Find(id);
            if (Other == null) { return NotFound(); }
            if (model.Quantity > Other.Quantity) { return BadRequest("The quantity is not available"); }
            Other.Quantity -= 1;
            _con.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Minus(Guid id)
        {

            var Other = _con.Others.Find(id);
            if (Other == null) { return NotFound(); }
            Other.Quantity += 1;
            _con.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

