using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderFood.Commands.CreateFood;
using MarketMadeinSudan.Application.Features.FolderFood.Commands.UpdateFood;
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
    public class FoodController : Controller
    {
        private readonly MarketMadeinSudanDbContext _con;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFoodRepository _FoodRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;
        public FoodController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService, IPublishersRepository publishersRepository,
            IFoodRepository FoodRepository, IMapper mapper, MarketMadeinSudanDbContext con,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _FoodRepository = FoodRepository;
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
                var model = await _FoodRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _FoodRepository.GetFoodDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _FoodRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var relatedProducts = await _con.Foods
                .Where(p => p.FoodName == model.FoodName).ToListAsync();
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
        public async Task<ActionResult> Create(CreateFoodCommand Food, List<IFormFile> Image)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                Food model = new Food
                {
                    PublishersId = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId).Select(x => x.PublishersId).FirstOrDefault(),
                    FoodName = Food.FoodName,
                    EmailCompany = Food.EmailCompany,
                    Description = Food.Description,
                    PhoneCompany = Food.PhoneCompany,
                    ImageUrl = Food.ImageUrl,
                    ImageProduct = Food.ImageProduct,
                    PictureProduct = Food.PictureProduct,
                    Quantity = Food.Quantity,
                    DateOfEstablishment = Food.DateOfEstablishment,
                    WebSite = Food.WebSite,
                    MeasruingUnit = Food.MeasruingUnit,
                    FounderAddress = Food.FounderAddress,
                    DescriptionCompany = Food.DescriptionCompany,
                    Pirce = Food.Pirce,
                    NameCompany = Food.NameCompany,
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

                    await _FoodRepository.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(Food);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _FoodRepository.GetByIdAsync(id);
            UpdateFoodCommand UpdateFood = new UpdateFoodCommand
            {
                PublishersId = model.PublishersId,
                MeasruingUnit = model.MeasruingUnit,
                EmailCompany = model.EmailCompany,
                FoodId = model.FoodId,
                FoodName = model.FoodName,
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

            return View(UpdateFood);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateFoodCommand updateFoodCommand, List<IFormFile> Image)
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
                            updateFoodCommand.ImageUrl = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updateFoodCommand.ImageProduct = dataStream.ToArray();
                        }
                        else if (i == 2)
                        {
                            updateFoodCommand.PictureProduct = dataStream.ToArray();
                        }
                    }
                }
                Food UpdateFood = new Food
                {
                    EmailCompany = updateFoodCommand.EmailCompany,
                    MeasruingUnit = updateFoodCommand.MeasruingUnit,
                    PublishersId = updateFoodCommand.PublishersId,
                    FoodId = updateFoodCommand.FoodId,
                    FoodName = updateFoodCommand.FoodName,
                    Description = updateFoodCommand.Description,
                    ImageUrl = updateFoodCommand.ImageUrl,
                    ImageProduct = updateFoodCommand.ImageProduct,
                    PictureProduct = updateFoodCommand.PictureProduct,
                    Quantity = updateFoodCommand.Quantity,
                    PhoneCompany = updateFoodCommand.PhoneCompany,
                    Pirce = updateFoodCommand.Pirce,
                    DateOfEstablishment = updateFoodCommand.DateOfEstablishment,
                    WebSite = updateFoodCommand.WebSite,
                    FounderAddress = updateFoodCommand.FounderAddress,
                    DescriptionCompany = updateFoodCommand.DescriptionCompany,
                    NameCompany = updateFoodCommand.NameCompany,
                    UserId = updateFoodCommand.UserId
                };

                await _FoodRepository.UpdateAsync(UpdateFood);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateFoodCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid FoodId)
        {
            try
            {

                var deleteFoodCommand = new Food() { FoodId = FoodId };

                await _FoodRepository.DeleteAsync(deleteFoodCommand);
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
            var result = _FoodRepository.Search().Where(a => a.FoodName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Plus(Guid id, Food model)
        {
            var Food = _con.Foods.Find(id);
            if (Food == null) { return NotFound(); }
            if (model.Quantity > Food.Quantity) { return BadRequest("The quantity is not available"); }
            Food.Quantity -= 1;
            _con.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Minus(Guid id)
        {

            var Food = _con.Foods.Find(id);
            if (Food == null) { return NotFound(); }
            Food.Quantity += 1;
            _con.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

