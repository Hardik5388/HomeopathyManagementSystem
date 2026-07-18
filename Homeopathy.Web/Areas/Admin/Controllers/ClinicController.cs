using Homeopathy.Application.Common.Results;
using Homeopathy.Application.DTOs.Clinics;
using Homeopathy.Application.Features.Clinics.Commands.CreateClinic;
using Homeopathy.Application.Features.Clinics.Queries.GetClinicList;
using Homeopathy.Application.Interfaces.Clinics;
using Homeopathy.Web.Areas.Admin.ViewModels.Clinic;
using Homeopathy.Web.Areas.Admin.ViewModels.Common;
using Homeopathy.Web.Services.FileStorage;
using Homeopathy.Web.UI.Factories;
using Homeopathy.Web.UI.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Homeopathy.Web.Areas.Admin.Controllers
{
    public class ClinicController : AdminBaseController
    {
        private readonly IClinicService _clinicService;
        private readonly IFileStorageService _fileStorageService;
        private readonly IPaginationBuilder _paginationBuilder;
        private readonly IGridFactory _gridFactory;
        public ClinicController(
       IClinicService clinicService,
       IFileStorageService fileStorageService,IPaginationBuilder paginationBuilder, IGridFactory gridFactory)
        {
            _clinicService = clinicService;
            _fileStorageService = fileStorageService;
            _paginationBuilder = paginationBuilder;
            _gridFactory = gridFactory;
        }
        public async Task<IActionResult> Index(ClinicListRequest request)
        {

            var result = await _clinicService.GetAllAsync(request);

            var model = new ClinicIndexViewModel
            {
                Filter = new SearchFilterViewModel
                {
                    SearchTerm = request.SearchTerm,
                    IsActive = request.IsActive
                },

                Grid = _gridFactory.Create(
                    result,
                    request,
                    Url,
                    nameof(Index))
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
