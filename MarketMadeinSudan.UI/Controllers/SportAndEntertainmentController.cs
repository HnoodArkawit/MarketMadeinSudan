using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Commands.CreateSportAndEntertainment;
using MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Commands.UpdateSportAndEntertainment;
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
    public class SportAndEntertainmentController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISportAndEntertainmentRepository _SportAndEntertainmentRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public SportAndEntertainmentController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            ISportAndEntertainmentRepository SportAndEntertainmentRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _SportAndEntertainmentRepository = SportAndEntertainmentRepository;
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
                var model = await _SportAndEntertainmentRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _SportAndEntertainmentRepository.GetSportAndEntertainmentDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _SportAndEntertainmentRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var relatedProducts = await _con.SportAndEntertainments
                .Where(p => p.SportAndEntertainmentName == model.SportAndEntertainmentName).ToListAsync();
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
        public async Task<ActionResult> Create(CreateSportAndEntertainmentCommand SportAndEntertainment, List<IFormFile> Image)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                SportAndEntertainment model = new SportAndEntertainment
                {
                    PublishersId = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault(),
                    SportAndEntertainmentName = SportAndEntertainment.SportAndEntertainmentName,
                    EmailCompany = SportAndEntertainment.EmailCompany,
                    Description = SportAndEntertainment.Description,
                    PhoneCompany = SportAndEntertainment.PhoneCompany,
                    ImageUrl = SportAndEntertainment.ImageUrl,
                    ImageProduct = SportAndEntertainment.ImageProduct,
                    PictureProduct = SportAndEntertainment.PictureProduct,
                    Quantity = SportAndEntertainment.Quantity,
                    DateOfEstablishment = SportAndEntertainment.DateOfEstablishment,
                    WebSite = SportAndEntertainment.WebSite,
                    MeasruingUnit = SportAndEntertainment.MeasruingUnit,
                    FounderAddress = SportAndEntertainment.FounderAddress,
                    DescriptionCompany = SportAndEntertainment.DescriptionCompany,
                    Pirce = SportAndEntertainment.Pirce,
                    NameCompany = SportAndEntertainment.NameCompany,
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

                    await _SportAndEntertainmentRepository.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(SportAndEntertainment);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _SportAndEntertainmentRepository.GetByIdAsync(id);
            UpdateSportAndEntertainmentCommand UpdateSportAndEntertainment = new UpdateSportAndEntertainmentCommand
            {
                PublishersId = model.PublishersId,
                MeasruingUnit = model.MeasruingUnit,
                EmailCompany = model.EmailCompany,
                SportAndEntertainmentId = model.SportAndEntertainmentId,
                SportAndEntertainmentName = model.SportAndEntertainmentName,
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

            return View(UpdateSportAndEntertainment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateSportAndEntertainmentCommand updateSportAndEntertainmentCommand, List<IFormFile> Image)
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
                            updateSportAndEntertainmentCommand.ImageUrl = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updateSportAndEntertainmentCommand.ImageProduct = dataStream.ToArray();
                        }
                        else if (i == 2)
                        {
                            updateSportAndEntertainmentCommand.PictureProduct = dataStream.ToArray();
                        }
                    }
                }
                SportAndEntertainment UpdateSportAndEntertainment = new SportAndEntertainment
                {
                    EmailCompany = updateSportAndEntertainmentCommand.EmailCompany,
                    MeasruingUnit = updateSportAndEntertainmentCommand.MeasruingUnit,
                    PublishersId = updateSportAndEntertainmentCommand.PublishersId,
                    SportAndEntertainmentId = updateSportAndEntertainmentCommand.SportAndEntertainmentId,
                    SportAndEntertainmentName = updateSportAndEntertainmentCommand.SportAndEntertainmentName,
                    Description = updateSportAndEntertainmentCommand.Description,
                    ImageUrl = updateSportAndEntertainmentCommand.ImageUrl,
                    ImageProduct = updateSportAndEntertainmentCommand.ImageProduct,
                    PictureProduct = updateSportAndEntertainmentCommand.PictureProduct,
                    Quantity = updateSportAndEntertainmentCommand.Quantity,
                    PhoneCompany = updateSportAndEntertainmentCommand.PhoneCompany,
                    Pirce = updateSportAndEntertainmentCommand.Pirce,
                    DateOfEstablishment = updateSportAndEntertainmentCommand.DateOfEstablishment,
                    WebSite = updateSportAndEntertainmentCommand.WebSite,
                    FounderAddress = updateSportAndEntertainmentCommand.FounderAddress,
                    DescriptionCompany = updateSportAndEntertainmentCommand.DescriptionCompany,
                    NameCompany = updateSportAndEntertainmentCommand.NameCompany,
                    UserId = updateSportAndEntertainmentCommand.UserId
                };

                await _SportAndEntertainmentRepository.UpdateAsync(UpdateSportAndEntertainment);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateSportAndEntertainmentCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid SportAndEntertainmentId)
        {
            try
            {

                var deleteSportAndEntertainmentCommand = new SportAndEntertainment() { SportAndEntertainmentId = SportAndEntertainmentId };

                await _SportAndEntertainmentRepository.DeleteAsync(deleteSportAndEntertainmentCommand);
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
            var result = _SportAndEntertainmentRepository.Search().Where(a => a.SportAndEntertainmentName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id, SportAndEntertainment model)
        {
            var SportAndEntertainment = _con.SportAndEntertainments.Find(id);
            if (SportAndEntertainment == null) { return NotFound(); }
            if (model.Quantity > SportAndEntertainment.Quantity) { return BadRequest("The quantity is not available"); }
            SportAndEntertainment.Quantity -= 1;
            _con.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Minus(Guid id)
        {

            var SportAndEntertainment = _con.SportAndEntertainments.Find(id);
            if (SportAndEntertainment == null) { return NotFound(); }
            SportAndEntertainment.Quantity += 1;
            _con.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

