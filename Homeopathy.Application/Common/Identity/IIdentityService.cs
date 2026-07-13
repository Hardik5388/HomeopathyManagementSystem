using Homeopathy.Application.Features.Authentication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Common.Identity
{
    public interface IIdentityService
    {
        Task<bool> LoginAsync(LoginDto dto);

        Task LogoutAsync();

        Task<bool> CreateRoleAsync(CreateRoleDto dto);

        Task<bool> CreateUserAsync(CreateUserDto dto);

        Task<bool> AssignRoleAsync(
            string email,
            string roleName);

        Task<bool> IsInRoleAsync(
            string userId,
            string roleName);

        Task<string?> GetUserIdAsync(string email);
    }
}
