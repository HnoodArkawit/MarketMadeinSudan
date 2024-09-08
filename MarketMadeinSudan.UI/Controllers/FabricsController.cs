using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderFabrics.Commands.CreateFabrics;
using MarketMadeinSudan.Application.Features.FolderFabrics.Commands.UpdateFabrics;
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
    public class FabricsController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFabricsRepository _FabricsRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public FabricsController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            IFabricsRepository FabricsRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _FabricsRepository = FabricsRepository;
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
                var model = await _FabricsRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _FabricsRepository.GetFabricsDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _FabricsRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var relatedProducts = await _con.Fabricss
                .Where(p => p.FabricsName == model.FabricsName).ToListAsync();
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
        public async Task<ActionResult> Create(CreateFabricsCommand Fabrics, List<IFormFile> Image)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                Fabrics model = new Fabrics
                {
                    PublishersId = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault(),
                    FabricsName = Fabrics.FabricsName,
                    EmailCompany = Fabrics.EmailCompany,
                    Description = Fabrics.Description,
                    PhoneCompany = Fabrics.PhoneCompany,
                    ImageUrl = Fabrics.ImageUrl,
                    ImageProduct = Fabrics.ImageProduct,
                    PictureProduct = Fabrics.PictureProduct,
                    Quantity = Fabrics.Quantity,
                    DateOfEstablishment = Fabrics.DateOfEstablishment,
                    WebSite = Fabrics.WebSite,
                    MeasruingUnit = Fabrics.MeasruingUnit,
                    FounderAddress = Fabrics.FounderAddress,
                    DescriptionCompany = Fabrics.DescriptionCompany,
                    Pirce = Fabrics.Pirce,
                    NameCompany = Fabrics.NameCompany,
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

                    await _FabricsRepository.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(Fabrics);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _FabricsRepository.GetByIdAsync(id);
            UpdateFabricsCommand UpdateFabrics = new UpdateFabricsCommand
            {
                PublishersId = model.PublishersId,
                MeasruingUnit = model.MeasruingUnit,
                EmailCompany = model.EmailCompany,
                FabricsId = model.FabricsId,
                FabricsName = model.FabricsName,
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

            return View(UpdateFabrics);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateFabricsCommand updateFabricsCommand, List<IFormFile> Image)
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
                            updateFabricsCommand.ImageUrl = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updateFabricsCommand.ImageProduct = dataStream.ToArray();
                        }
                        else if (i == 2)
                        {
                            updateFabricsCommand.PictureProduct = dataStream.ToArray();
                        }
                    }
                }
                Fabrics UpdateFabrics = new Fabrics
                {
                    EmailCompany = updateFabricsCommand.EmailCompany,
                    MeasruingUnit = updateFabricsCommand.MeasruingUnit,
                    PublishersId = updateFabricsCommand.PublishersId,
                    FabricsId = updateFabricsCommand.FabricsId,
                    FabricsName = updateFabricsCommand.FabricsName,
                    Description = updateFabricsCommand.Description,
                    ImageUrl = updateFabricsCommand.ImageUrl,
                    ImageProduct = updateFabricsCommand.ImageProduct,
                    PictureProduct = updateFabricsCommand.PictureProduct,
                    Quantity = updateFabricsCommand.Quantity,
                    PhoneCompany = updateFabricsCommand.PhoneCompany,
                    Pirce = updateFabricsCommand.Pirce,
                    DateOfEstablishment = updateFabricsCommand.DateOfEstablishment,
                    WebSite = updateFabricsCommand.WebSite,
                    FounderAddress = updateFabricsCommand.FounderAddress,
                    DescriptionCompany = updateFabricsCommand.DescriptionCompany,
                    NameCompany = updateFabricsCommand.NameCompany,
                    UserId = updateFabricsCommand.UserId
                };

                await _FabricsRepository.UpdateAsync(UpdateFabrics);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateFabricsCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid FabricsId)
        {
            try
            {

                var deleteFabricsCommand = new Fabrics() { FabricsId = FabricsId };

                await _FabricsRepository.DeleteAsync(deleteFabricsCommand);
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
            var result = _FabricsRepository.Search().Where(a => a.FabricsName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id, Fabrics model)
        {
            var Fabrics = _con.Fabricss.Find(id);
            if (Fabrics == null) { return NotFound(); }
            if (model.Quantity > Fabrics.Quantity) { return BadRequest("The quantity is not available"); }
            Fabrics.Quantity -= 1;
            _con.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Minus(Guid id)
        {

            var Fabrics = _con.Fabricss.Find(id);
            if (Fabrics == null) { return NotFound(); }
            Fabrics.Quantity += 1;
            _con.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

