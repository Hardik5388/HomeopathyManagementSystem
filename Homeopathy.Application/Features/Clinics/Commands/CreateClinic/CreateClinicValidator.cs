using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Features.Clinics.Commands.CreateClinic
{
    public sealed class CreateClinicValidator : AbstractValidator<CreateClinicDto>
    {
        public CreateClinicValidator()
        {
            RuleFor(x => x.ClinicCode)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.RegistrationNumber)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(150);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.AddressLine1)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.State)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Website)
                .MaximumLength(250)
                .When(x => !string.IsNullOrWhiteSpace(x.Website));

            RuleFor(x => x.Logo)
                .MaximumLength(500)
                .When(x => !string.IsNullOrWhiteSpace(x.Logo));
        }
    }
}
