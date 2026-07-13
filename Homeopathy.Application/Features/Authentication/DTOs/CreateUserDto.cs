using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Features.Authentication.DTOs
{
    public sealed class CreateUserDto
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public bool EmailConfirmed { get; set; } = true;

        public bool IsActive { get; set; } = true;
    }
}
