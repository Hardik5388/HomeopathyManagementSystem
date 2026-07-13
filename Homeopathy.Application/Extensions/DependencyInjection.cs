using FluentValidation;
using Homeopathy.Application.Interfaces.Clinics;
using Homeopathy.Application.Mappings;
using Homeopathy.Application.Services.Clinics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ClinicProfile).Assembly);

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.AddScoped<IClinicService, ClinicService>();

            return services;
        }
    }
}
