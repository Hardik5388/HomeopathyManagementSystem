using Homeopathy.Application.Common.Identity;
using Homeopathy.Application.Features.Authentication.DTOs;
using Homeopathy.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<bool> AssignRoleAsync(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return false;

            if (await _userManager.IsInRoleAsync(user, roleName))
                return true;

            var result = await _userManager.AddToRoleAsync(user, roleName);

            return result.Succeeded;
        }

        public async Task<bool> CreateRoleAsync(CreateRoleDto dto)
        {
            if (await _roleManager.RoleExistsAsync(dto.Name))
                return true;

            var result = await _roleManager.CreateAsync(
                new IdentityRole(dto.Name));

            return result.Succeeded;
        }

        public async Task<bool> CreateUserAsync(CreateUserDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
                return true;

            user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EmailConfirmed = dto.EmailConfirmed,
                IsActive = dto.IsActive
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            return result.Succeeded;
        }

        public async Task<string?> GetUserIdAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user?.Id;
        }

        public async Task<bool> IsInRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return false;

            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<bool> LoginAsync(LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                        dto.Email,
                        dto.Password,
                        dto.RememberMe,
                        lockoutOnFailure: true);

            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }
    }
}
