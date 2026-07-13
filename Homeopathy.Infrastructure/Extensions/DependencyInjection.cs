using Homeopathy.Application.Common.Identity;
using Homeopathy.Domain.Entities.Identity;
using Homeopathy.Domain.Interfaces.Clinics;
using Homeopathy.Domain.Interfaces.Repositories;
using Homeopathy.Infrastructure.Identity;
using Homeopathy.Infrastructure.Persistence;
using Homeopathy.Infrastructure.Repositories.Clinics;
using Homeopathy.Infrastructure.Repositories.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
         this IServiceCollection services,
         IConfiguration configuration)
        {
            services.AddDbContext<HomeopathyDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IIdentityService, IdentityService>();

            services
            .AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;

                // User
                options.User.RequireUniqueEmail = true;

                // Lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            })

            .AddEntityFrameworkStores<HomeopathyDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";

                options.Cookie.Name = "Homeopathy.Auth";

                options.SlidingExpiration = true;

                options.ExpireTimeSpan = TimeSpan.FromHours(8);
            });

            return services;
        }

    }
}
