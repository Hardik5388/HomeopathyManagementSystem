using AutoMapper;
using Homeopathy.Domain.Common.Pagination;
using Homeopathy.Application.DTOs.Clinics;
using Homeopathy.Application.Features.Clinics.Commands.CreateClinic;
using Homeopathy.Application.Features.Clinics.Commands.UpdateClinic;
using Homeopathy.Application.Features.Clinics.Queries.GetClinicList;
using Homeopathy.Application.Interfaces.Clinics;
using Homeopathy.Domain.Entities;
using Homeopathy.Domain.Interfaces.Clinics;
using Homeopathy.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Services.Clinics
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClinicService(
            IClinicRepository clinicRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _clinicRepository = clinicRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(CreateClinicDto dto)
        {
            //var clinic = new Clinic
            //{
            //    ClinicCode = dto.ClinicCode,
            //    Name = dto.Name,
            //    Email = dto.Email,
            //    PhoneNumber = dto.PhoneNumber,
            //    IsActive = dto.IsActive,
            //    CreatedAt = DateTime.UtcNow
            //};
            var clinic = _mapper.Map<Clinic>(dto);

            clinic.CreatedAt = DateTime.UtcNow;

            await _clinicRepository.AddAsync(clinic);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var clinic = await _clinicRepository.GetByIdAsync(id);

            if (clinic == null)
                throw new Exception("Clinic not found.");

            clinic.IsDeleted = true;
            clinic.UpdatedAt = DateTime.UtcNow;

            _clinicRepository.Update(clinic);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResult<ClinicListDto>> GetAllAsync(ClinicListRequest request)
        {
            var result = await _clinicRepository.GetPagedAsync(
             request.SearchTerm,
             request.IsActive,
             request.PageNumber,
             request.PageSize);

            return new PagedResult<ClinicListDto>
            {
                Items = _mapper.Map<List<ClinicListDto>>(result.Items),
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount
            };


        }

        public async Task<ClinicDto?> GetByIdAsync(int id)
        {
            var clinic = await _clinicRepository.GetByIdAsync(id);

            if (clinic == null)
                return null;

            return new ClinicDto
            {
                Id = clinic.Id,
                ClinicCode = clinic.ClinicCode,
                Name = clinic.Name,
                Email = clinic.Email,
                PhoneNumber = clinic.PhoneNumber,
                IsActive = clinic.IsActive
            };
        }

        public async Task UpdateAsync(UpdateClinicDto dto)
        {
            var clinic = await _clinicRepository.GetByIdAsync(dto.Id);

            //if (clinic == null)
            //    throw new Exception("Clinic not found.");

            //clinic.Name = dto.Name;
            //clinic.Email = dto.Email;
            //clinic.PhoneNumber = dto.PhoneNumber;
            //clinic.IsActive = dto.IsActive;
            //clinic.UpdatedAt = DateTime.UtcNow;

            _mapper.Map(dto, clinic);

            clinic.UpdatedAt = DateTime.UtcNow;

            _clinicRepository.Update(clinic);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
