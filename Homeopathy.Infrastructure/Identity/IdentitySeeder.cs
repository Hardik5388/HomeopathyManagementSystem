using Homeopathy.Application.Common.Identity;
using Homeopathy.Application.Features.Authentication.DTOs;
using Homeopathy.Domain.Constants;
using Homeopathy.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Infrastructure.Identity
{
    public sealed class IdentitySeeder
    {
        private readonly IIdentityService _identityService;
        private readonly DefaultAdminOptions _options;

        public IdentitySeeder(
            IIdentityService identityService,
            IOptions<DefaultAdminOptions> options)
        {
            _identityService = identityService;
            _options = options.Value;
        }

        public async Task SeedAsync()
        {
            await CreateRolesAsync();
            await CreateSuperAdminAsync();
        }
        private async Task CreateRolesAsync()
        {
            string[] roles =
            {
            Roles.SuperAdmin,
            Roles.Admin,
            Roles.Doctor,
            Roles.Patient
        };

            foreach (var role in roles)
            {
                if (!await _identityService.RoleExistsAsync(role))
                {
                    await _identityService.CreateRoleAsync(new CreateRoleDto
                    {
                        Name = role
                    });
                }
            }
        }
        private async Task CreateSuperAdminAsync()
        {
            if (await _identityService.UserExistsAsync(_options.Email))
                return;

            bool created = await _identityService.CreateUserAsync(new CreateUserDto
            {
                Email = _options.Email,
                Password = _options.Password,
                FirstName = _options.FirstName,
                LastName = _options.LastName,
                EmailConfirmed = true,
                IsActive = true
            });

            if (created)
            {
                await _identityService.AssignRoleAsync(
                    _options.Email,
                    Roles.SuperAdmin);
            }
        }
    }
}
