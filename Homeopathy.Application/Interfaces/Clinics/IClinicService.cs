using Homeopathy.Application.DTOs.Clinics;
using Homeopathy.Application.Features.Clinics.Commands.CreateClinic;
using Homeopathy.Application.Features.Clinics.Commands.UpdateClinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Interfaces.Clinics
{
    public interface IClinicService
    {
        Task<List<ClinicListDto>> GetAllAsync();

        Task<ClinicDto?> GetByIdAsync(int id);

        Task AddAsync(CreateClinicDto dto);

        Task UpdateAsync(UpdateClinicDto dto);

        Task DeleteAsync(int id);
    }
}
