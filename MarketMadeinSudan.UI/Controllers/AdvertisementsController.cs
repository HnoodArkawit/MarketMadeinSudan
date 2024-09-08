using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderAccessories.Commands.UpdateAccessories;
using MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.CreateAdvertisements;
using MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.UpdateAdvertisements;
using MarketMadeinSudan.Domin;
using MarketMadeinSudan.Persistence;
using MarketMadeinSudan.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MartyrDecember.UI.Controllers
{

    public class AdvertisementsController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAdvertisementsRepository _AdvertisementsService;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;

        public AdvertisementsController(UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService, IAdvertisementsRepository AdvertisementsService, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _AdvertisementsService = AdvertisementsService;
           _mapper = mapper;
            _hosting = hosting;
            _userManager = userManager;
            _authorizationService = authorizationService;

        }

        // GET: AdvertisementsPictureController
        public async Task<ActionResult> Index()
        {
            SetUser();
            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _AdvertisementsService.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _AdvertisementsService.GetAdvertisementsDataByUser(UserId).Where(x => x.UserId == UserId);

                return View(model);

            }
        }


        // GET: AdvertisementsPictureController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: AdvertisementsPictureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAdvertisementsCommand AdvertisementsImage, List<IFormFile> Image)
        {
            try
            {
                Advertisements model = new Advertisements
                {
                    ProductName = AdvertisementsImage.ProductName,
                    Description = AdvertisementsImage.Description,
                    NameCompany = AdvertisementsImage.NameCompany,
                    Quantity = AdvertisementsImage.Quantity,
                    PirceGo = AdvertisementsImage.PirceGo,
                    PirceEnd = AdvertisementsImage.PirceEnd,
                    ImageUrl = AdvertisementsImage.ImageUrl,
                    UserId = _userManager.GetUserAsync(User).Result.Id
                };

                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files.FirstOrDefault();

                    //check file size and extension

                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        model.ImageUrl = dataStream.ToArray();
                    }

                    await _AdvertisementsService.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(AdvertisementsImage);
        }

        // GET: AdvertisementsPictureController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _AdvertisementsService.GetByIdAsync(id);
            UpdateAdvertisementsCommand UpdateMarPic = new UpdateAdvertisementsCommand
            {
                AdvertisementId = model.AdvertisementId,
                ProductName = model.ProductName,
                NameCompany = model.NameCompany,
                Quantity = model.Quantity,
                PirceGo = model.PirceGo,
                PirceEnd = model.PirceEnd,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId=model.UserId

            };

            return View(UpdateMarPic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateAdvertisementsCommand updateAdvertisementsCommand)
        {
            try
            {

                    var files = Request.Form.Files;

                if (files.Any())
                {
                    var file = files.FirstOrDefault();

                    using var dataStream = new MemoryStream();

                    await file.CopyToAsync(dataStream);

                    updateAdvertisementsCommand.ImageUrl = dataStream.ToArray();
                }

                Advertisements UpdateAdvertisements = new Advertisements
                    {
                        AdvertisementId = updateAdvertisementsCommand.AdvertisementId,
                    ProductName = updateAdvertisementsCommand.ProductName,
                    NameCompany = updateAdvertisementsCommand.NameCompany,
                    Quantity = updateAdvertisementsCommand.Quantity,
                    PirceGo = updateAdvertisementsCommand.PirceGo,
                    PirceEnd = updateAdvertisementsCommand.PirceEnd,
                    Description = updateAdvertisementsCommand.Description,
                    ImageUrl = updateAdvertisementsCommand.ImageUrl,
                        UserId=updateAdvertisementsCommand.UserId
                    };

                    await _AdvertisementsService.UpdateAsync(UpdateAdvertisements);
                TempData["success"] = "تم تعديل البيانات";
                return RedirectToAction(nameof(Index));
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateAdvertisementsCommand);
        }

        // GET: AdvertisementsPictureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdvertisementsPictureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid AdvertisementId)
        {
            try
            {
                var deleteAdvertisementsPictureCommand = new Advertisements() { AdvertisementId = AdvertisementId };

                await _AdvertisementsService.DeleteAsync(deleteAdvertisementsPictureCommand);
                TempData["success"] = " تمت عملية الحذف بنجاح ";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

    }
}
