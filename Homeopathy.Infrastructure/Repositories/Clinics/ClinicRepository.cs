using Homeopathy.Domain.Entities;
using Homeopathy.Domain.Interfaces.Clinics;
using Homeopathy.Domain.Interfaces.Repositories;
using Homeopathy.Infrastructure.Persistence;
using Homeopathy.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Infrastructure.Repositories.Clinics
{
    public class ClinicRepository : Repository<Clinic>,IClinicRepository
    {
        public ClinicRepository(HomeopathyDbContext context)
        : base(context)
        {
        }

        public async Task<List<Clinic>> GetActiveClinicsAsync()
        {
            return await _context.Clinics
           .Where(x => x.IsActive)
           .OrderBy(x => x.Name)
           .ToListAsync();
        }

        public async Task<Clinic?> GetByClinicCodeAsync(string clinicCode)
        {
            return await _context.Clinics
            .FirstOrDefaultAsync(x => x.ClinicCode == clinicCode);
        }

        public async Task<bool> IsClinicCodeExistsAsync(string clinicCode)
        {
            return await _context.Clinics
            .AnyAsync(x => x.ClinicCode == clinicCode);
        }
    }
}
