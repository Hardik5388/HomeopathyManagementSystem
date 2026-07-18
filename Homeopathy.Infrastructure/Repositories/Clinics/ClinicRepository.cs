using Azure.Core;
using Homeopathy.Domain.Common.Pagination;
using Homeopathy.Application.DTOs.Clinics;
using Homeopathy.Application.Features.Clinics.Queries.GetClinicList;
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

        //public async Task<System.Linq.Dynamic.Core.PagedResult<Clinic>> GetPagedAsync(string? searchTerm, bool? isActive, int pageNumber, int pageSize)
        //{
        //    IQueryable<Clinic> query = _context.Clinics;

        //    // Search
        //    if (!string.IsNullOrWhiteSpace(searchTerm))
        //    {
        //        query = query.Where(c =>
        //            c.ClinicCode.Contains(searchTerm) ||
        //            c.Name.Contains(searchTerm) ||
        //            c.PhoneNumber.Contains(searchTerm));
        //    }

        //    // Status
        //    if (isActive.HasValue)
        //    {
        //        query = query.Where(c => c.IsActive == isActive.Value);
        //    }

        //    var totalCount = await query.CountAsync();

        //    var items = await query
        //        .OrderBy(c => c.Name)
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    return new PagedResult<Clinic>
        //    {
        //        Items = items,
        //        PageNumber = pageNumber,
        //        PageSize = pageSize,
        //        TotalCount = totalCount
        //    };
        //}

        public async Task<bool> IsClinicCodeExistsAsync(string clinicCode)
        {
            return await _context.Clinics
            .AnyAsync(x => x.ClinicCode == clinicCode);
        }

        public async Task<PagedResult<Clinic>> GetPagedAsync(string? searchTerm, bool? isActive, int pageNumber, int pageSize)
        {
            IQueryable<Clinic> query = _context.Clinics;

            // Search
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c =>
                    c.ClinicCode.Contains(searchTerm) ||
                    c.Name.Contains(searchTerm) ||
                    c.PhoneNumber.Contains(searchTerm));
            }

            // Status
            if (isActive.HasValue)
            {
                query = query.Where(c => c.IsActive == isActive.Value);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Clinic>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };

        }
    }
}
