using Homeopathy.Application.Features.Clinics.Commands.CreateClinic;
using Homeopathy.Application.Interfaces.Clinics;
using Homeopathy.Web.Areas.Admin.ViewModels.Clinic;
using Homeopathy.Web.Services.FileStorage;
using Microsoft.AspNetCore.Mvc;

namespace Homeopathy.Web.Areas.Admin.Controllers
{
    public class ClinicController : AdminBaseController
    {
        private readonly IClinicService _clinicService;
        private readonly IFileStorageService _fileStorageService;
        public ClinicController(
       IClinicService clinicService,
       IFileStorageService fileStorageService)
        {
            _clinicService = clinicService;
            _fileStorageService = fileStorageService;
        }
        public async Task<IActionResult> Index()
        {
            var clinics = await _clinicService.GetAllAsync();

            var model = new ClinicIndexViewModel
            {
                Clinics = clinics
            };

            return View(model);
        }
        public IActionResult Create()
        {
            return View(new ClinicCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClinicCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var logoPath = await _fileStorageService.UploadAsync(
                model.Logo,
                "clinics");

            var dto = new CreateClinicDto
            {
                ClinicCode = model.ClinicCode,
                Name = model.Name,
                RegistrationNumber = model.RegistrationNumber,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                State = model.State,
                Country = model.Country,
                PostalCode = model.PostalCode,
                Website = model.Website,
                Logo = logoPath,
                IsActive = model.IsActive
            };

            await _clinicService.AddAsync(dto);

            TempData["Success"] = "Clinic created successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}
