using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Commands.CreateAgriculturalCrops;
using MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Commands.UpdateAgriculturalCrops;
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
    public class AgriculturalCropsController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAgriculturalCropsRepository _AgriculturalCropsRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public AgriculturalCropsController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            IAgriculturalCropsRepository AgriculturalCropsRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _AgriculturalCropsRepository = AgriculturalCropsRepository;
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
                var model = await _AgriculturalCropsRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _AgriculturalCropsRepository.GetAgriculturalCropsDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _AgriculturalCropsRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var relatedProducts = await _con.AgriculturalCropss
                .Where(p => p.AgriculturalCropsName == model.AgriculturalCropsName).ToListAsync();
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
        public async Task<ActionResult> Create(CreateAgriculturalCropsCommand AgriculturalCrops, List<IFormFile> Image)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                AgriculturalCrops model = new AgriculturalCrops
                {
                    PublishersId = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault(),
                    AgriculturalCropsName = AgriculturalCrops.AgriculturalCropsName,
                    EmailCompany = AgriculturalCrops.EmailCompany,
                    Description = AgriculturalCrops.Description,
                    PhoneCompany = AgriculturalCrops.PhoneCompany,
                    ImageUrl = AgriculturalCrops.ImageUrl,
                    ImageProduct = AgriculturalCrops.ImageProduct,
                    PictureProduct = AgriculturalCrops.PictureProduct,
                    Quantity = AgriculturalCrops.Quantity,
                    DateOfEstablishment = AgriculturalCrops.DateOfEstablishment,
                    WebSite = AgriculturalCrops.WebSite,
                    MeasruingUnit = AgriculturalCrops.MeasruingUnit,
                    FounderAddress = AgriculturalCrops.FounderAddress,
                    DescriptionCompany = AgriculturalCrops.DescriptionCompany,
                    Pirce = AgriculturalCrops.Pirce,
                    NameCompany = AgriculturalCrops.NameCompany,
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

                    await _AgriculturalCropsRepository.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(AgriculturalCrops);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _AgriculturalCropsRepository.GetByIdAsync(id);
            UpdateAgriculturalCropsCommand UpdateAgriculturalCrops = new UpdateAgriculturalCropsCommand
            {
                PublishersId = model.PublishersId,
                MeasruingUnit = model.MeasruingUnit,
                EmailCompany = model.EmailCompany,
                AgriculturalCropsId = model.AgriculturalCropsId,
                AgriculturalCropsName = model.AgriculturalCropsName,
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

            return View(UpdateAgriculturalCrops);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateAgriculturalCropsCommand updateAgriculturalCropsCommand, List<IFormFile> Image)
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
                            updateAgriculturalCropsCommand.ImageUrl = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updateAgriculturalCropsCommand.ImageProduct = dataStream.ToArray();
                        }
                        else if (i == 2)
                        {
                            updateAgriculturalCropsCommand.PictureProduct = dataStream.ToArray();
                        }
                    }
                }
                AgriculturalCrops UpdateAgriculturalCrops = new AgriculturalCrops
                {
                    EmailCompany = updateAgriculturalCropsCommand.EmailCompany,
                    MeasruingUnit = updateAgriculturalCropsCommand.MeasruingUnit,
                    PublishersId = updateAgriculturalCropsCommand.PublishersId,
                    AgriculturalCropsId = updateAgriculturalCropsCommand.AgriculturalCropsId,
                    AgriculturalCropsName = updateAgriculturalCropsCommand.AgriculturalCropsName,
                    Description = updateAgriculturalCropsCommand.Description,
                    ImageUrl = updateAgriculturalCropsCommand.ImageUrl,
                    ImageProduct = updateAgriculturalCropsCommand.ImageProduct,
                    PictureProduct = updateAgriculturalCropsCommand.PictureProduct,
                    Quantity = updateAgriculturalCropsCommand.Quantity,
                    PhoneCompany = updateAgriculturalCropsCommand.PhoneCompany,
                    Pirce = updateAgriculturalCropsCommand.Pirce,
                    DateOfEstablishment = updateAgriculturalCropsCommand.DateOfEstablishment,
                    WebSite = updateAgriculturalCropsCommand.WebSite,
                    FounderAddress = updateAgriculturalCropsCommand.FounderAddress,
                    DescriptionCompany = updateAgriculturalCropsCommand.DescriptionCompany,
                    NameCompany = updateAgriculturalCropsCommand.NameCompany,
                    UserId = updateAgriculturalCropsCommand.UserId
                };

                await _AgriculturalCropsRepository.UpdateAsync(UpdateAgriculturalCrops);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateAgriculturalCropsCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid AgriculturalCropsId)
        {
            try
            {

                var deleteAgriculturalCropsCommand = new AgriculturalCrops() { AgriculturalCropsId = AgriculturalCropsId };

                await _AgriculturalCropsRepository.DeleteAsync(deleteAgriculturalCropsCommand);
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
            var result = _AgriculturalCropsRepository.Search().Where(a => a.AgriculturalCropsName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id, AgriculturalCrops model)
        {
            var AgriculturalCrops = _con.AgriculturalCropss.Find(id);
            if (AgriculturalCrops == null) { return NotFound(); }
            if (model.Quantity > AgriculturalCrops.Quantity) { return BadRequest("The quantity is not available"); }
            AgriculturalCrops.Quantity -= 1;
            _con.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Minus(Guid id)
        {

            var AgriculturalCrops = _con.AgriculturalCropss.Find(id);
            if (AgriculturalCrops == null) { return NotFound(); }
            AgriculturalCrops.Quantity += 1;
            _con.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

