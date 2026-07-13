using Homeopathy.Application.DTOs.Clinics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Interfaces.Clinics
{
    public interface IClinicService
    {
        Task<List<ClinicDto>> GetAllAsync();

        Task<ClinicDto?> GetByIdAsync(int id);

        Task AddAsync(ClinicDto dto);

        Task UpdateAsync(ClinicDto dto);

        Task DeleteAsync(int id);
    }
}
