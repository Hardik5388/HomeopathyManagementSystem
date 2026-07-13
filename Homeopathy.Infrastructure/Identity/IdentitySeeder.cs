using Homeopathy.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Infrastructure.Identity
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            // Will implement next
        }
    }
}
