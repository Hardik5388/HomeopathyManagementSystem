using Homeopathy.Domain.Common;
using Homeopathy.Domain.Entities;
using Homeopathy.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Domain.Interfaces.Clinics
{
    public interface IClinicRepository : IRepository<Clinic>
    {
        Task<Clinic?> GetByClinicCodeAsync(string clinicCode);

        Task<bool> IsClinicCodeExistsAsync(string clinicCode);

        Task<List<Clinic>> GetActiveClinicsAsync();
    }
}
