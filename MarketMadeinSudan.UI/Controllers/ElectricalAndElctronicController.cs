using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.CreateElectricalAndElctronic;
using MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.UpdateElectricalAndElctronic;
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
    public class ElectricalAndElctronicController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IElectricalAndElctronicRepository _ElectricalAndElctronicRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public ElectricalAndElctronicController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            IElectricalAndElctronicRepository ElectricalAndElctronicRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _ElectricalAndElctronicRepository = ElectricalAndElctronicRepository;
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
                var model = await _ElectricalAndElctronicRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _ElectricalAndElctronicRepository.GetElectricalAndElctronicDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _ElectricalAndElctronicRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var relatedProducts = await _con.ElectricalAndElctronics
                .Where(p => p.ElectricalAndElctronicName == model.ElectricalAndElctronicName).ToListAsync();
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
        public async Task<ActionResult> Create(CreateElectricalAndElctronicCommand ElectricalAndElctronic, List<IFormFile> Image)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ElectricalAndElctronic model = new ElectricalAndElctronic
                {
                    PublishersId = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault(),
                    ElectricalAndElctronicName = ElectricalAndElctronic.ElectricalAndElctronicName,
                    EmailCompany = ElectricalAndElctronic.EmailCompany,
                    Description = ElectricalAndElctronic.Description,
                    PhoneCompany = ElectricalAndElctronic.PhoneCompany,
                    ImageUrl = ElectricalAndElctronic.ImageUrl,
                    ImageProduct = ElectricalAndElctronic.ImageProduct,
                    PictureProduct = ElectricalAndElctronic.PictureProduct,
                    Quantity = ElectricalAndElctronic.Quantity,
                    DateOfEstablishment = ElectricalAndElctronic.DateOfEstablishment,
                    WebSite = ElectricalAndElctronic.WebSite,
                    MeasruingUnit = ElectricalAndElctronic.MeasruingUnit,
                    FounderAddress = ElectricalAndElctronic.FounderAddress,
                    DescriptionCompany = ElectricalAndElctronic.DescriptionCompany,
                    Pirce = ElectricalAndElctronic.Pirce,
                    NameCompany = ElectricalAndElctronic.NameCompany,
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

                    await _ElectricalAndElctronicRepository.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(ElectricalAndElctronic);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _ElectricalAndElctronicRepository.GetByIdAsync(id);
            UpdateElectricalAndElctronicCommand UpdateElectricalAndElctronic = new UpdateElectricalAndElctronicCommand
            {
                PublishersId = model.PublishersId,
                MeasruingUnit = model.MeasruingUnit,
                EmailCompany = model.EmailCompany,
                ElectricalAndElctronicId = model.ElectricalAndElctronicId,
                ElectricalAndElctronicName = model.ElectricalAndElctronicName,
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

            return View(UpdateElectricalAndElctronic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateElectricalAndElctronicCommand updateElectricalAndElctronicCommand, List<IFormFile> Image)
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
                            updateElectricalAndElctronicCommand.ImageUrl = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updateElectricalAndElctronicCommand.ImageProduct = dataStream.ToArray();
                        }
                        else if (i == 2)
                        {
                            updateElectricalAndElctronicCommand.PictureProduct = dataStream.ToArray();
                        }
                    }
                }
                ElectricalAndElctronic UpdateElectricalAndElctronic = new ElectricalAndElctronic
                {
                    EmailCompany = updateElectricalAndElctronicCommand.EmailCompany,
                    MeasruingUnit = updateElectricalAndElctronicCommand.MeasruingUnit,
                    PublishersId = updateElectricalAndElctronicCommand.PublishersId,
                    ElectricalAndElctronicId = updateElectricalAndElctronicCommand.ElectricalAndElctronicId,
                    ElectricalAndElctronicName = updateElectricalAndElctronicCommand.ElectricalAndElctronicName,
                    Description = updateElectricalAndElctronicCommand.Description,
                    ImageUrl = updateElectricalAndElctronicCommand.ImageUrl,
                    ImageProduct = updateElectricalAndElctronicCommand.ImageProduct,
                    PictureProduct = updateElectricalAndElctronicCommand.PictureProduct,
                    Quantity = updateElectricalAndElctronicCommand.Quantity,
                    PhoneCompany = updateElectricalAndElctronicCommand.PhoneCompany,
                    Pirce = updateElectricalAndElctronicCommand.Pirce,
                    DateOfEstablishment = updateElectricalAndElctronicCommand.DateOfEstablishment,
                    WebSite = updateElectricalAndElctronicCommand.WebSite,
                    FounderAddress = updateElectricalAndElctronicCommand.FounderAddress,
                    DescriptionCompany = updateElectricalAndElctronicCommand.DescriptionCompany,
                    NameCompany = updateElectricalAndElctronicCommand.NameCompany,
                    UserId = updateElectricalAndElctronicCommand.UserId
                };

                await _ElectricalAndElctronicRepository.UpdateAsync(UpdateElectricalAndElctronic);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateElectricalAndElctronicCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid ElectricalAndElctronicId)
        {
            try
            {

                var deleteElectricalAndElctronicCommand = new ElectricalAndElctronic() { ElectricalAndElctronicId = ElectricalAndElctronicId };

                await _ElectricalAndElctronicRepository.DeleteAsync(deleteElectricalAndElctronicCommand);
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
            var result = _ElectricalAndElctronicRepository.Search().Where(a => a.ElectricalAndElctronicName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id, ElectricalAndElctronic model)
        {
            var ElectricalAndElctronic = _con.ElectricalAndElctronics.Find(id);
            if (ElectricalAndElctronic == null) { return NotFound(); }
            if (model.Quantity > ElectricalAndElctronic.Quantity) { return BadRequest("The quantity is not available"); }
            ElectricalAndElctronic.Quantity -= 1;
            _con.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Minus(Guid id)
        {

            var ElectricalAndElctronic = _con.ElectricalAndElctronics.Find(id);
            if (ElectricalAndElctronic == null) { return NotFound(); }
            ElectricalAndElctronic.Quantity += 1;
            _con.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

