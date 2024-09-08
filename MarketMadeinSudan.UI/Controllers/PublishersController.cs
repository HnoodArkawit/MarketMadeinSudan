using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderPublishers.Commands.CreatePublishers;
using MarketMadeinSudan.Application.Features.FolderPublishers.Commands.UpdatePublishers;
using MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Commands.UpdateSportAndEntertainment;
using MarketMadeinSudan.Domin;
using MarketMadeinSudan.Persistence;
using MarketMadeinSudan.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketMadeinSudan.UI.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;

        public PublishersController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService,
            IPublishersRepository publishersRepository, IMapper mapper,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _PublishersRepository = publishersRepository;
            _mapper = mapper;
            _hosting = hosting;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }
        // GET: MarPicController
        public async Task<ActionResult> Index()
        {
            SetUser();
            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _PublishersRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId);
                return View(model);

            }
        }

        public async Task<ActionResult> PublishersControl()
        {
            SetUser();
            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _PublishersRepository.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _PublishersRepository.GetPublishersDataByUser(UserId).Where(x => x.UserId == UserId);
                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _PublishersRepository.GetByIdAsync(id);
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
        public async Task<ActionResult> Create(CreatePublishersCommand publishers, List<IFormFile> Image)
        {
            try
            {
                Publishers model = new Publishers
                {
                    NameCompany = publishers.NameCompany,
                    DescriptionCompany = publishers.DescriptionCompany,
                    FounderAddress = publishers.FounderAddress,
                    DateOfEstablishment = publishers.DateOfEstablishment,
                    WebSite = publishers.WebSite,
                    Email = publishers.Email,
                    Employment = publishers.Employment,
                    Phone = publishers.Phone,
                    ImageCompany = publishers.ImageCompany,
                    PdfFile = publishers.PdfFile,
                    FilePdf = publishers.FilePdf,
                    UserId = _userManager.GetUserAsync(User).Result.Id
                };
                if (Request.Form.Files.Count > 0)
                {
                    var files = Request.Form.Files;

                    //check file size and extension

                    using (var dataStream1 = new MemoryStream())
                    {
                        await files[0].CopyToAsync(dataStream1);
                        model.ImageCompany = dataStream1.ToArray();
                    }

                    using (var dataStream2 = new MemoryStream())
                    {
                        await files[1].CopyToAsync(dataStream2);
                        model.FilePdf = dataStream2.ToArray();
                    }
                    using (var dataStream3 = new MemoryStream())
                    {
                        await files[2].CopyToAsync(dataStream3);
                        model.PdfFile = dataStream3.ToArray();
                    }

                    await _PublishersRepository.AddAsync(model);
                    TempData["success"] = "تم تسجيل المؤسسةسيتم التواصل معك في اقرب فرصة لاكمال الإجراءت";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(publishers);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _PublishersRepository.GetByIdAsync(id);
            UpdatePublishersCommand UpdatePublishers = new UpdatePublishersCommand
            {
                PublishersId = model.PublishersId,
                NameCompany = model.NameCompany,
                DescriptionCompany = model.DescriptionCompany,
                FounderAddress = model.FounderAddress,
                DateOfEstablishment = model.DateOfEstablishment,
                WebSite = model.WebSite,
                Email = model.Email,
                Employment = model.Employment,
                Phone = model.Phone,
                PdfFile = model.PdfFile,
                FilePdf = model.FilePdf,
                ImageCompany = model.ImageCompany,
                UserId = model.UserId
            };

            return View(UpdatePublishers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdatePublishersCommand updatePublishersCommand, List<IFormFile> Image)
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
                            updatePublishersCommand.ImageCompany = dataStream.ToArray();
                        }
                        else if (i == 1)
                        {
                            updatePublishersCommand.PdfFile = dataStream.ToArray();
                        }
                        else if (i == 2)
                        {
                            updatePublishersCommand.FilePdf = dataStream.ToArray();
                        }
                    }
                }
                Publishers UpdatePublishers = new Publishers
                {
                    PublishersId = updatePublishersCommand.PublishersId,
                    NameCompany = updatePublishersCommand.NameCompany,
                    DescriptionCompany = updatePublishersCommand.DescriptionCompany,
                    FounderAddress = updatePublishersCommand.FounderAddress,
                    DateOfEstablishment = updatePublishersCommand.DateOfEstablishment,
                    WebSite = updatePublishersCommand.WebSite,
                    Email = updatePublishersCommand.Email,
                    PdfFile = updatePublishersCommand.PdfFile,
                    FilePdf = updatePublishersCommand.FilePdf,
                    Employment = updatePublishersCommand.Employment,
                    Phone = updatePublishersCommand.Phone,
                    ImageCompany = updatePublishersCommand.ImageCompany,
                    UserId = updatePublishersCommand.UserId
                };

                await _PublishersRepository.UpdateAsync(UpdatePublishers);
                TempData["success"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updatePublishersCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid PublishersId)
        {
            try
            {

                var deletePublishersCommand = new Publishers() { PublishersId = PublishersId };

                await _PublishersRepository.DeleteAsync(deletePublishersCommand);
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
            var result = _PublishersRepository.Search().Where(a => a.NameCompany.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

    }
}
