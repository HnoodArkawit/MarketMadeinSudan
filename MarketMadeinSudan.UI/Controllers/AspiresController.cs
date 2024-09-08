using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderAspires.Commands.CreateAspires;
using MarketMadeinSudan.Application.Features.FolderAspires.Commands.UpdateAspires;
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
    public class AspiresController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAspiresRepository _AspiresRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public AspiresController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            IAspiresRepository AspiresRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _AspiresRepository = AspiresRepository;
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
                var model = await _AspiresRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _AspiresRepository.GetAspiresDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _AspiresRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var relatedProducts = await _con.Aspires
                .Where(p => p.AspiresName == model.AspiresName).ToListAsync();
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
        public async Task<ActionResult> Create(CreateAspiresCommand Aspires, List<IFormFile> Image)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                Aspires model = new Aspires
                {
                    PublishersId = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault(),
                    AspiresName = Aspires.AspiresName,
                    EmailCompany = Aspires.EmailCompany,
                    Description = Aspires.Description,
                    PhoneCompany = Aspires.PhoneCompany,
                    ImageUrl = Aspires.ImageUrl,
                    ImageProduct = Aspires.ImageProduct,
                    PictureProduct = Aspires.PictureProduct,
                    Quantity = Aspires.Quantity,
                    DateOfEstablishment = Aspires.DateOfEstablishment,
                    WebSite = Aspires.WebSite,
                    MeasruingUnit = Aspires.MeasruingUnit,
                    FounderAddress = Aspires.FounderAddress,
                    DescriptionCompany = Aspires.DescriptionCompany,
                    Pirce = Aspires.Pirce,
                    NameCompany = Aspires.NameCompany,
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

                    await _AspiresRepository.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(Aspires);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _AspiresRepository.GetByIdAsync(id);
            UpdateAspiresCommand UpdateAspires = new UpdateAspiresCommand
            {
                PublishersId = model.PublishersId,
                MeasruingUnit = model.MeasruingUnit,
                EmailCompany = model.EmailCompany,
                AspiresId = model.AspiresId,
                AspiresName = model.AspiresName,
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

            return View(UpdateAspires);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateAspiresCommand updateAspiresCommand, List<IFormFile> Image)
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
                            updateAspiresCommand.ImageUrl = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updateAspiresCommand.ImageProduct = dataStream.ToArray();
                        }
                        else if (i == 2)
                        {
                            updateAspiresCommand.PictureProduct = dataStream.ToArray();
                        }
                    }
                }
                Aspires UpdateAspires = new Aspires
                {
                    EmailCompany = updateAspiresCommand.EmailCompany,
                    MeasruingUnit = updateAspiresCommand.MeasruingUnit,
                    PublishersId = updateAspiresCommand.PublishersId,
                    AspiresId = updateAspiresCommand.AspiresId,
                    AspiresName = updateAspiresCommand.AspiresName,
                    Description = updateAspiresCommand.Description,
                    ImageUrl = updateAspiresCommand.ImageUrl,
                    ImageProduct = updateAspiresCommand.ImageProduct,
                    PictureProduct = updateAspiresCommand.PictureProduct,
                    Quantity = updateAspiresCommand.Quantity,
                    PhoneCompany = updateAspiresCommand.PhoneCompany,
                    Pirce = updateAspiresCommand.Pirce,
                    DateOfEstablishment = updateAspiresCommand.DateOfEstablishment,
                    WebSite = updateAspiresCommand.WebSite,
                    FounderAddress = updateAspiresCommand.FounderAddress,
                    DescriptionCompany = updateAspiresCommand.DescriptionCompany,
                    NameCompany = updateAspiresCommand.NameCompany,
                    UserId = updateAspiresCommand.UserId
                };

                await _AspiresRepository.UpdateAsync(UpdateAspires);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateAspiresCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid AspiresId)
        {
            try
            {

                var deleteAspiresCommand = new Aspires() { AspiresId = AspiresId };

                await _AspiresRepository.DeleteAsync(deleteAspiresCommand);
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
            var result = _AspiresRepository.Search().Where(a => a.AspiresName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id, Aspires model)
        {
            var Aspires = _con.Aspires.Find(id);
            if (Aspires == null) { return NotFound(); }
            if (model.Quantity > Aspires.Quantity) { return BadRequest("The quantity is not available"); }
            Aspires.Quantity -= 1;
            _con.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Minus(Guid id)
        {

            var Aspires = _con.Aspires.Find(id);
            if (Aspires == null) { return NotFound(); }
            Aspires.Quantity += 1;
            _con.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

